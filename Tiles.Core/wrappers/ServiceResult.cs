// File: Tiles.Core/Wrappers/ServiceResult.cs
using System;

namespace Tiles.Core.Wrappers
{
    /// <summary>
    /// Represents a standard response for a service operation, indicating success or failure.
    /// </summary>
    public class ServiceResult
    {
        /// <summary>
        /// Indicates whether the service operation was successful.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Optional message providing details about the result.
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// Creates a successful service result with an optional message.
        /// </summary>
        /// <param name="message">A message describing the success.</param>
        /// <returns>A ServiceResult with success set to true.</returns>
        public static ServiceResult CreateSuccess(string message = "Success")
        {
            return new ServiceResult { Success = true, Message = message };
        }

        /// <summary>
        /// Creates a failed service result with an optional message.
        /// </summary>
        /// <param name="message">A message describing the failure.</param>
        /// <returns>A ServiceResult with success set to false.</returns>
        public static ServiceResult CreateFailure(string message = "Failure")
        {
            return new ServiceResult { Success = false, Message = message };
        }
    }

    /// <summary>
    /// Represents a generic version of ServiceResult that includes data of type T.
    /// </summary>
    /// <typeparam name="T">The type of data returned in the result.</typeparam>
    public class ServiceResult<T> : ServiceResult
    {
        /// <summary>
        /// The data returned from the service operation.
        /// </summary>
        public T? Data { get; set; }

        /// <summary>
        /// Creates a successful service result containing data and an optional message.
        /// </summary>
        /// <param name="data">The data to return.</param>
        /// <param name="message">A message describing the success.</param>
        /// <returns>A ServiceResult with success and data.</returns>
        public static ServiceResult<T> CreateSuccess(T data, string message = "Success")
        {
            return new ServiceResult<T> { Success = true, Data = data, Message = message };
        }

        /// <summary>
        /// Creates a failed service result with an optional message.
        /// </summary>
        /// <param name="message">A message describing the failure.</param>
        /// <returns>A ServiceResult with success set to false and no data.</returns>
        public new static ServiceResult<T> CreateFailure(string message = "Failure")
        {
            return new ServiceResult<T> { Success = false, Message = message };
        }
    }
}
