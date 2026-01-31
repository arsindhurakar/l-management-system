using LManagement.API.Models;
using LManagement.API.Models.Responses;
using LManagement.Application.Models.Pagination;

namespace LManagement.API.Extensions
{
    public static class ApiResponseExtension
    {
        public static PaginatedApiResponse<IEnumerable<T>> ToPaginationResponse<T>(
            this PagedResult<T> pagedResult,
            string message = "Data retrieved successfully")
        {
            var meta = new PaginationMeta
            {
                Page = pagedResult.Page,
                PageSize = pagedResult.PageSize,
                TotalCount = pagedResult.TotalCount,
                TotalPages = pagedResult.TotalPages,
                HasPreviousPage = pagedResult.HasPreviousPage,
                HasNextPage = pagedResult.HasNextPage
            };

            return PaginatedApiResponse<IEnumerable<T>>.SuccessResponse(pagedResult.Items, meta, message);
        }

    }
}
