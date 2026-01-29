using LManagement.Application.Models.Pagination;
using Microsoft.EntityFrameworkCore;

namespace LManagement.Application.Handlers
{
    public static class PaginationHandler
    {
        public static async Task<PagedResult<T>> PaginateAsync<T>(
            this IQueryable<T> query,
            PageRequest pageRequest,
            bool includeCount = true)
        {
            int totalCount = 0;

            if (includeCount)
            {
                totalCount = await query.CountAsync();
            }

            var items = await query
                .Skip((pageRequest.Page - 1) * pageRequest.PageSize)
                .Take(pageRequest.PageSize)
                .ToListAsync();

            return new PagedResult<T>
            {
                Items = items,
                TotalCount = totalCount,
                Page = pageRequest.Page,
                PageSize = pageRequest.PageSize
            };
        }
    }
}