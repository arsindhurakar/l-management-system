using LManagement.Application.Models.Pagination;
using Microsoft.EntityFrameworkCore;

namespace LManagement.Infrastructure.Extensions
{
    public static class SortingExtension
    {
        public static IQueryable<T> ApplySorting<T>(this IQueryable<T> query, PageRequest pageRequest)
            where T : class
        {
            if (string.IsNullOrWhiteSpace(pageRequest.SortBy))
            {
                return query;
            }

            var propertyName = pageRequest.SortBy;

            query = pageRequest.IsDescending
                ? query.OrderByDescending(entity => EF.Property<object>(entity, propertyName))
                : query.OrderBy(entity => EF.Property<object>(entity, propertyName));

            return query;
        }
    }
}
