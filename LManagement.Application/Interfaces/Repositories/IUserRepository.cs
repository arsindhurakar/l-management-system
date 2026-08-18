using LManagement.Application.Models.Pagination;
using LManagement.Domain.Entities;

namespace LManagement.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<PagedResult<User>> GetAllAsync(PageRequest pageRequest);
    }
}
