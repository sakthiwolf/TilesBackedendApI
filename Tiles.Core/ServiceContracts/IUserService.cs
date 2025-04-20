// File: Tiles.Core/ServiceContracts/UserManagement/Application/Interfaces/IUserService.cs

using System;
using System.Threading.Tasks;
using Tiles.Core.DTO.UserDto;
using Tiles.Core.Wrappers;

namespace Tiles.Core.ServiceContracts.UserManagement.Application.Interfaces
{
    /// <summary>
    /// Interface defining the contract for user management services.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="dto">The data for the user to be registered.</param>
        /// <returns>A ServiceResult indicating success or failure.</returns>
        Task<ServiceResult> RegisterUserAsync(UserRequestDto dto);

        /// <summary>
        /// Retrieves a paginated list of users based on search criteria.
        /// </summary>
        /// <param name="search">The search keyword to filter users.</param>
        /// <param name="pageNo">The page number to retrieve.</param>
        /// <param name="rowsPerPage">The number of users per page.</param>
        /// <returns>A PaginatedResult containing a list of UserResponseDto objects.</returns>
        Task<PaginatedResult<UserResponseDto>> GetUsersAsync(string search, int pageNo, int rowsPerPage);

        /// <summary>
        /// Retrieves a specific user by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the user.</param>
        /// <returns>A UserResponseDto if the user is found, or null if not.</returns>
        Task<UserResponseDto?> GetUserByIdAsync(Guid id);

        /// <summary>
        /// Updates the details of an existing user.
        /// </summary>
        /// <param name="id">The unique identifier of the user to update.</param>
        /// <param name="dto">The updated user data.</param>
        /// <returns>A ServiceResult indicating success or failure.</returns>
        Task<ServiceResult> UpdateUserAsync(Guid id, UserRequestDto dto);

        /// <summary>
        /// Deletes a user by their unique identifier.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>A ServiceResult indicating whether the deletion was successful.</returns>
        Task<ServiceResult> DeleteUserAsync(Guid id);

        /// <summary>
        /// Authenticates a user using their login credentials.
        /// </summary>
        /// <param name="dto">The login data (email and password).</param>
        /// <returns>A ServiceResult containing a TokenResponseDto if authentication succeeds.</returns>
        Task<ServiceResult<TokenResponseDto>> LoginAsync(LoginDto dto);

        /// <summary>
        /// Updates the user's password.
        /// </summary>
        /// <param name="dto">The new password data.</param>
        /// <returns>A ServiceResult indicating success or failure.</returns>
        Task<ServiceResult> UpdatePasswordAsync(UpdatePasswordDto dto);

        /// <summary>
        /// Initiates the password reset process by sending an OTP to the user's email.
        /// </summary>
        /// <param name="email">The email address of the user who forgot the password.</param>
        /// <returns>A ServiceResult indicating success or failure.</returns>
        Task<ServiceResult> ForgotPasswordAsync(string email);

        /// <summary>
        /// Sends an email to a specified recipient.
        /// </summary>
        /// <param name="toEmail">The recipient's email address.</param>
        /// <param name="toName">The recipient's name.</param>
        /// <param name="subject">The email subject line.</param>
        /// <param name="htmlBody">The email HTML body content.</param>
        Task SendEmailAsync(string toEmail, string toName, string subject, string htmlBody);

        /// <summary>
        /// Verifies the OTP sent to the user's email for password reset.
        /// </summary>
        /// <param name="email">The user's email address.</param>
        /// <param name="otp">The OTP to verify.</param>
        /// <returns>A ServiceResult indicating whether the OTP is valid and not expired.</returns>
        Task<ServiceResult> VerifyOtpAsync(string email, string otp);
    }
}
