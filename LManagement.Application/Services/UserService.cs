using LManagement.Application.Interfaces.Services;
using LManagement.Application.Models.Pagination;
using LManagement.Domain.Entities;

namespace LManagement.Application.Services
{
    public class UserService : IUserService
    {
        public UserService()
        {

        }

        public async Task<PagedResult<User>> GetAllUsersAsync(PageRequest pageRequest)
        {
            return null;
        }
    }
}