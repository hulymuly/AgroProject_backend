using AgroProject.Data;
using AgroProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgroProject.Repositories
{
    public interface IReagentUsageRepository
    {
        Task<IEnumerable<ReagentUsage>> GetAllUsagesAsync();
        Task AddUsageAsync(ReagentUsage usage);
        Task<IEnumerable<ReagentUsage>> GetUsagesByReagentIdAsync(int reagentId);
        Task<IEnumerable<ReagentUsage>> GetMonthlyUsageAsync(int month, int year);
        Task<ReagentUsage> GetUsageByIdAsync(int id);
    }

    public class ReagentUsageRepository : IReagentUsageRepository
    {
        private readonly AppDbContext _context;

        public ReagentUsageRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ReagentUsage>> GetAllUsagesAsync()
        {
            return await _context.ReagentUsages.ToListAsync();
        }

        public async Task AddUsageAsync(ReagentUsage usage)
        {
            await _context.ReagentUsages.AddAsync(usage);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ReagentUsage>> GetUsagesByReagentIdAsync(int reagentId)
        {
            return await _context.ReagentUsages
                .Where(u => u.ReagentId == reagentId)
                .ToListAsync();
        }

        public async Task<IEnumerable<ReagentUsage>> GetMonthlyUsageAsync(int month, int year)
        {
            return await _context.ReagentUsages
                .Where(u => u.Date.Month == month && u.Date.Year == year)
                .ToListAsync();
        }

        public async Task<ReagentUsage> GetUsageByIdAsync(int id)
        {
            return await _context.ReagentUsages.FindAsync(id);
        }
    }
}