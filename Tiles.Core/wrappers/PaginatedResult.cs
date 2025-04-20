// File: Tiles.Core/Wrappers/PaginatedResult.cs
using System;
using System.Collections.Generic;

namespace Tiles.Core.Wrappers
{
    /// <summary>
    /// Represents a paginated result that extends a service result with pagination metadata.
    /// </summary>
    public class PaginatedResult<T> : ServiceResult
    {
        /// <summary>
        /// The actual data returned for the current page.
        /// </summary>
        public List<T> Data { get; set; } = new();

        /// <summary>
        /// The current page number.
        /// </summary>
        public int PageNo { get; set; }

        /// <summary>
        /// The number of records per page.
        /// </summary>
        public int RowsPerPage { get; set; }

        /// <summary>
        /// The total number of records available.
        /// </summary>
        public int TotalRecords { get; set; }

        /// <summary>
        /// The total number of pages calculated from total records and rows per page.
        /// </summary>
        public int TotalPages => (int)Math.Ceiling((double)TotalRecords / RowsPerPage);

        /// <summary>
        /// Creates a successful paginated result with metadata and data.
        /// </summary>
        /// <param name="data">The paginated list of items.</param>
        /// <param name="pageNo">The current page number.</param>
        /// <param name="rowsPerPage">Number of rows per page.</param>
        /// <param name="totalRecords">Total number of available records.</param>
        /// <param name="message">Optional success message.</param>
        /// <returns>A populated successful paginated result.</returns>
        public static PaginatedResult<T> CreateSuccess(List<T> data, int pageNo, int rowsPerPage, int totalRecords, string message = "Success")
        {
            return new PaginatedResult<T>
            {
                Data = data,
                PageNo = pageNo,
                RowsPerPage = rowsPerPage,
                TotalRecords = totalRecords,
                Success = true,
                Message = message
            };
        }

        /// <summary>
        /// Creates a failure paginated result with an error message.
        /// </summary>
        /// <param name="message">Optional failure message.</param>
        /// <returns>A failed paginated result.</returns>
        public new static PaginatedResult<T> CreateFailure(string message = "Failure")
        {
            return new PaginatedResult<T>
            {
                Success = false,
                Message = message
            };
        }
    }
}
