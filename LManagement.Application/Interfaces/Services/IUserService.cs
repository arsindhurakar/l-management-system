using LManagement.Application.Models.Pagination;
using LManagement.Domain.Entities;

namespace LManagement.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<PagedResult<User>> GetAllUsersAsync(PageRequest pageRequest);
    }
}