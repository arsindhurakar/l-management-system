using AutoMapper;
using LManagement.Application.DTOs.LeadDtos;
using LManagement.Application.Interfaces.Services;
using LManagement.Application.Models.Pagination;
using LManagement.Domain.Entities;
using LManagement.Infrastructure.Repositories.Interfaces;

namespace LManagement.Application.Services
{
    public class LeadService : ILeadService
    {
        private readonly ILeadRepository _leadRepository;
        private readonly IMapper _mapper;

        public LeadService(ILeadRepository leadRepository, IMapper mapper)
        {
            _leadRepository = leadRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<Lead>> GetAllLeadsAsync(PageRequest pageRequest)
        {
            return await _leadRepository.GetAllAsync(pageRequest);
        }

        public async Task<Lead?> GetLeadByIdAsync(int id)
        {
            return await _leadRepository.GetByIdAsync(id);
        }

        public async Task<Lead> CreateLeadAsync(LeadCreateDto leadCreateDto)
        {
            var lead = _mapper.Map<Lead>(leadCreateDto);

            return await _leadRepository.CreateAsync(lead);
        }

        public async Task<Lead?> UpdateLeadAsync(int id, LeadUpdateDto leadUpdateDto)
        {

            var lead = await _leadRepository.GetByIdAsync(id);

            if (lead == null)
            {
                return null;
            }

            _mapper.Map(leadUpdateDto, lead);

            return await _leadRepository.UpdateAsync(lead);
        }

        public async Task<bool> DeleteLeadAsync(int id)
        {
            return await _leadRepository.DeleteAsync(id);
        }
    }
}
