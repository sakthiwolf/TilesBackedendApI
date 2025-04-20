using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tiles.Core.Domain.Entites;

namespace Tiles.Core.Domain.RepositroyContracts
{
    /// <summary>
    /// Interface defining the contract for user-related database operations.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Retrieves a user by their email address.
        /// </summary>
        /// <param name="email">The user's email address.</param>
        /// <returns>The user if found, or null if not.</returns>
        Task<User?> GetByEmailAsync(string email);

        /// <summary>
        /// Retrieves a user by their unique identifier.
        /// </summary>
        /// <param name="id">The user's unique ID.</param>
        /// <returns>The user if found, or null if not.</returns>
        Task<User?> GetByIdAsync(Guid id);

        /// <summary>
        /// Retrieves a paginated list of users matching the given search criteria.
        /// </summary>
        /// <param name="search">Search keyword to filter users by name, email, etc.</param>
        /// <param name="pageNo">The current page number.</param>
        /// <param name="rowsPerPage">The number of users per page.</param>
        /// <returns>A list of users for the specified page.</returns>
        Task<List<User>> GetUsersAsync(string search, int pageNo, int rowsPerPage);

        /// <summary>
        /// Gets the total number of users that match the search criteria.
        /// </summary>
        /// <param name="search">Search keyword to filter users.</param>
        /// <returns>The total count of matching users.</returns>
        Task<int> GetTotalCountAsync(string search);

        /// <summary>
        /// Gets the next available serial number for a new user.
        /// </summary>
        /// <returns>The next serial number.</returns>
        Task<int> GetNextSerialNumberAsync();

        /// <summary>
        /// Adds a new user to the database.
        /// </summary>
        /// <param name="user">The user entity to add.</param>
        Task AddAsync(User user);

        /// <summary>
        /// Updates an existing user's details in the database.
        /// </summary>
        /// <param name="user">The user entity with updated data.</param>
        Task UpdateAsync(User user);

        /// <summary>
        /// Deletes a user from the database.
        /// </summary>
        /// <param name="user">The user entity to delete.</param>
        Task DeleteAsync(User user);
    }
}
