using AgroProject.Data;
using AgroProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgroProject.Repositories
{
    public interface IReagentRepository
    {
        Task<IEnumerable<ReaktivPrixod>> GetAllReagentsAsync();
        Task<ReaktivPrixod> GetReagentByIdAsync(int id);
        Task AddReagentAsync(ReaktivPrixod reagent);
        Task UpdateReagentAsync(int id, ReaktivPrixod updatedReagent);
        Task DeleteReagentAsync(int id);
        Task<IEnumerable<ReaktivPrixod>> GetReagentsByExpiryDateAsync(DateTime expiryDate);
    }

    public class ReagentRepository : IReagentRepository
    {
        private readonly AppDbContext _context;

        public ReagentRepository(AppDbContext context)
        {
                       _context = context;
        }

        public async Task<IEnumerable<ReaktivPrixod>> GetAllReagentsAsync()
        {
            return await _context.ReaktivPrixods.ToListAsync();
        }

        public async Task<ReaktivPrixod> GetReagentByIdAsync(int id)
        {
            return await _context.ReaktivPrixods.FindAsync(id);
        }

        public async Task AddReagentAsync(ReaktivPrixod reagent)
        {
            await _context.ReaktivPrixods.AddAsync(reagent);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateReagentAsync(int id, ReaktivPrixod updatedReagent)
        {
            var reagent = await _context.ReaktivPrixods.FindAsync(id);
            if (reagent != null)
            {
                reagent.Chistota = updatedReagent.Chistota; // Обновите другие поля по мере необходимости
                reagent.DataPrixoda = updatedReagent.DataPrixoda;
                reagent.Partia = updatedReagent.Partia;
                // и так далее для других полей...
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteReagentAsync(int id)
        {
            var reagent = await _context.ReaktivPrixods.FindAsync(id);
            if (reagent != null)
            {
                _context.ReaktivPrixods.Remove(reagent);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ReaktivPrixod>> GetReagentsByExpiryDateAsync(DateTime expiryDate)
        {
            return await _context.ReaktivPrixods
                .Where(r => r.DataIzgotovlenia.HasValue && r.DataIzgotovlenia.Value.AddYears(1) <= expiryDate)
                .ToListAsync();
        }
    }
}