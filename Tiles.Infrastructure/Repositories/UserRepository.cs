using Microsoft.EntityFrameworkCore;
using Tiles.Core.Domain.Entites;
using Tiles.Core.Domain.RepositroyContracts;
using Tiles.Infrastructure.data;

namespace Tiles.Infrastructure.Repositories
{
    // Concrete implementation of IUserRepository using Entity Framework Core
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        // Constructor to initialize the repository with the application's DbContext
        public UserRepository(AppDbContext context) => _context = context;

        // Retrieves a user by their email address
        public async Task<User?> GetByEmailAsync(string email) =>
            await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

        // Retrieves a user by their unique identifier (GUID)
        public async Task<User?> GetByIdAsync(Guid id) =>
            await _context.Users.FindAsync(id);

        // Retrieves a paginated list of users matching the search keyword (name, email, or phone)
        public async Task<List<User>> GetUsersAsync(string search, int pageNo, int rowsPerPage) =>
            await _context.Users
                .Where(u => u.Name.Contains(search) || u.Email.Contains(search) || u.Phone.Contains(search))
                .Skip((pageNo - 1) * rowsPerPage) // Skip users from previous pages
                .Take(rowsPerPage) // Take users for the current page
                .ToListAsync();

        // Gets the total count of users matching the search keyword (used for pagination)
        public async Task<int> GetTotalCountAsync(string search) =>
            await _context.Users
                .CountAsync(u => u.Name.Contains(search) || u.Email.Contains(search) || u.Phone.Contains(search));

        // Retrieves the next available serial number for a new user
        public async Task<int> GetNextSerialNumberAsync()
        {
            var max = await _context.Users.MaxAsync(u => (int?)u.SerialNumber); // Get the highest serial number
            return (max ?? 0) + 1; // Increment it or return 1 if no users exist
        }

        // Adds a new user to the database
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync(); // Save changes to persist the new user
        }

        // Updates an existing user's details
        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user); // Track changes to the user entity
            await _context.SaveChangesAsync(); // Persist changes to the database
        }

        // Deletes a user from the database
        public async Task DeleteAsync(User user)
        {
            _context.Users.Remove(user); // Mark the user entity for deletion
            await _context.SaveChangesAsync(); // Commit the deletion to the database
        }
    }
}
