using LManagement.Domain.Entities;
using LManagement.Infrastructure.Data;
using LManagement.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LManagement.Infrastructure.Repositories
{
    public class LeadRepository : ILeadRepository
    {
        private readonly ApplicationDbContext _context;

        public LeadRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Lead>> GetAllAsync()
        {
            return await _context.Leads
                .OrderByDescending(lead => lead.CreatedAt)
                .ToListAsync();
        }

        public async Task<Lead?> GetByIdAsync(int id)
        {
            return await _context.Leads
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<Lead> CreateAsync(Lead lead)
        {
            _context.Leads.Add(lead);
            await _context.SaveChangesAsync();

            return lead;
        }

        public async Task<Lead> UpdateAsync(Lead lead)
        {
            _context.Leads.Update(lead);
            await _context.SaveChangesAsync();

            return lead;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var lead = await _context.Leads.FindAsync(id);

            if (lead == null) {
                return false;
            }

            _context.Leads.Remove(lead);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
