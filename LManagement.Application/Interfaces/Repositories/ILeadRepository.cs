using LManagement.Domain.Entities;

namespace LManagement.Infrastructure.Repositories.Interfaces
{
    public interface ILeadRepository
    {
        Task<IEnumerable<Lead>> GetAllAsync();
        Task<Lead?> GetByIdAsync(int id);
        Task<Lead> CreateAsync(Lead lead);
        Task<Lead> UpdateAsync(Lead lead);
        Task<bool> DeleteAsync(int id);
        //Task<Lead?> GetByPhoneNumberAsync(string phoneNumber);
        //Task<bool> ExistsAsync(int id);
    }
}
