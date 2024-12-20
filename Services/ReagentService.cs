using AgroProject.Models;
using AgroProject.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgroProject.Services
{
    public interface IReagentService
    {
        Task<IEnumerable<ReaktivPrixod>> GetAllReagentsAsync();
        Task<ReaktivPrixod> GetReagentByIdAsync(int id);
        Task AddReagentAsync(ReaktivPrixod reagent);
        Task UpdateReagentAsync(int id, ReaktivPrixod updatedReagent);
        Task DeleteReagentAsync(int id);
        Task<IEnumerable<ReaktivPrixod>> CheckLowQuantityReagentsAsync();
        Task<IEnumerable<ReaktivPrixod>> CheckExpiringReagentsAsync();
    }

    public class ReagentService : IReagentService
    {
        private readonly IReagentRepository _reagentRepository;

        public ReagentService(IReagentRepository reagentRepository)
        {
            _reagentRepository = reagentRepository;
        }

        public async Task<IEnumerable<ReaktivPrixod>> GetAllReagentsAsync()
        {
            return await _reagentRepository.GetAllReagentsAsync();
        }

        public async Task<ReaktivPrixod> GetReagentByIdAsync(int id)
        {
            return await _reagentRepository.GetReagentByIdAsync(id);
        }

        public async Task AddReagentAsync(ReaktivPrixod reagent)
        {
            await _reagentRepository.AddReagentAsync(reagent);
        }

        public async Task UpdateReagentAsync(int id, ReaktivPrixod updatedReagent)
        {
            await _reagentRepository.UpdateReagentAsync(id, updatedReagent);
        }

        public async Task DeleteReagentAsync(int id)
        {
            await _reagentRepository.DeleteReagentAsync(id);
        }

        public async Task<IEnumerable<ReaktivPrixod>> CheckLowQuantityReagentsAsync()
        {
            return await _reagentRepository.GetLowQuantityReagentsAsync();
        }

        public async Task<IEnumerable<ReaktivPrixod>> CheckExpiringReagentsAsync()
        {
            return await _reagentRepository.GetExpiringReagentsAsync();
        }
    }
}