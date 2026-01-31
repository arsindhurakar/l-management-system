using LManagement.Application.Interfaces;
using LManagement.Domain.Entities;

namespace LManagement.Infrastructure.Providers
{
    public class SortFieldsProvider : ISortFieldsProvider
    {
        public string[] GetSortFields<T>()
        {
            return typeof(T) switch
            {
                Type type when type == typeof(Lead) => ["FirstName", "LastName", "Email", "Company", "Status", "CreatedAt", "UpdatedAt"],
                _ => Array.Empty<string>()
            };
        }
    }
}
