using AgroProject.Models;
using AgroProject.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgroProject.Services
{
    public interface IReagentUsageService
    {
        Task<IEnumerable<ReagentUsage>> GetAllUsagesAsync();
        Task AddUsageAsync(ReagentUsage usage);
        Task<IEnumerable<ReagentUsage>> GetUsagesByReagentIdAsync(int reagentId);
        Task<IEnumerable<ReagentUsage>> GetMonthlyUsageAsync(int month, int year);
        Task<ReagentUsage> GetUsageByIdAsync(int id);
    }

    public class ReagentUsageService : IReagentUsageService
    {
        private readonly IReagentUsageRepository _reagentUsageRepository;

        public ReagentUsageService(IReagentUsageRepository reagentUsageRepository)
        {
            _reagentUsageRepository = reagentUsageRepository;
        }

        public async Task<IEnumerable<ReagentUsage>> GetAllUsagesAsync()
        {
            return await _reagentUsageRepository.GetAllUsagesAsync();
        }

        public async Task AddUsageAsync(ReagentUsage usage)
        {
            await _reagentUsageRepository.AddUsageAsync(usage);
        }

        public async Task<IEnumerable<ReagentUsage>> GetUsagesByReagentIdAsync(int reagentId)
        {
            return await _reagentUsageRepository.GetUsagesByReagentIdAsync(reagentId);
        }

        public async Task<IEnumerable<ReagentUsage>> GetMonthlyUsageAsync(int month, int year)
        {
            return await _reagentUsageRepository.GetMonthlyUsageAsync(month, year);
        }

        public async Task<ReagentUsage> GetUsageByIdAsync(int id)
        {
            return await _reagentUsageRepository.GetUsageByIdAsync(id);
        }
    }
}