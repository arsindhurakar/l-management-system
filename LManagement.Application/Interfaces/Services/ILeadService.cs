using LManagement.Application.DTOs.LeadDtos;
using LManagement.Domain.Entities;

namespace LManagement.Application.Interfaces.Services
{
    public interface ILeadService
    {
        Task<IEnumerable<Lead>> GetAllLeadsAsync();
        Task<Lead?> GetLeadByIdAsync(int id);
        Task<Lead> CreateLeadAsync(LeadCreateDto leadCreateDto);
        Task<Lead?> UpdateLeadAsync(int id, LeadUpdateDto leadUpdateDto);
        Task<bool> DeleteLeadAsync(int id);
    }
}
