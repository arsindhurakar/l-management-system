using LManagement.Application.Interfaces.Repositories;
using LManagement.Application.Models.Pagination;
using LManagement.Domain.Entities;
using LManagement.Infrastructure.Data;

namespace LManagement.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<PagedResult<User>> GetAllAsync(PageRequest pageRequest)
        {
            return null;
        }
    }
}