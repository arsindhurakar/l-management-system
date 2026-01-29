using LManagement.API.Models;
using LManagement.Application.Models.Pagination;

namespace LManagement.API.Extensions
{
    public static class ApiResponseExtensions
    {
        public static ApiResponse<IEnumerable<T>> ToPaginationResponse<T>(
            this PagedResult<T> pagedResult,
            string message = "Data retrieved successfully")
        {
            return new ApiResponse<IEnumerable<T>>
            {
                Success = true,
                Message = message,
                Data = pagedResult.Items,
                Meta = new PaginationMeta
                {
                    Page = pagedResult.Page,
                    PageSize = pagedResult.PageSize,
                    TotalCount = pagedResult.TotalCount,
                    TotalPages = pagedResult.TotalPages,
                    HasPreviousPage = pagedResult.HasPreviousPage,
                    HasNextPage = pagedResult.HasNextPage
                }
            };
        }
       
    }
}
