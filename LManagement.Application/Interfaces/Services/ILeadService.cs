using LManagement.Application.DTOs.LeadDtos;
using LManagement.Application.Models.Pagination;
using LManagement.Domain.Entities;

namespace LManagement.Application.Interfaces.Services
{
    public interface ILeadService
    {
        Task<PagedResult<Lead>> GetAllLeadsAsync(PageRequest pageRequest);
        Task<Lead?> GetLeadByIdAsync(int id);
        Task<Lead> CreateLeadAsync(LeadCreateDto leadCreateDto);
        Task<Lead?> UpdateLeadAsync(int id, LeadUpdateDto leadUpdateDto);
        Task<bool> DeleteLeadAsync(int id);
    }
}
