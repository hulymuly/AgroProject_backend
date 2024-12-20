using AgroProject.Data;
using AgroProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgroProject.Repositories
{
    public interface ICultureRepository
    {
        Task<IEnumerable<Culture>> GetAllCulturesAsync();
        Task AddCultureAsync(Culture culture);
        Task DeleteCultureAsync(int id);
        Task UpdateCultureAsync(int id, Culture updatedCulture);
    }

    public class CultureRepository : ICultureRepository
    {
        private readonly AppDbContext _context;

        public CultureRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Culture>> GetAllCulturesAsync()
        {
            return await _context.Kultures.ToListAsync();
        }

        public async Task AddCultureAsync(Culture culture)
        {
            await _context.Kultures.AddAsync(culture);
            await _context.SaveChangesAsync();
        }
         public async Task AddCultureByIdAsync(Culture id)
        {
            await _context.Kultures.AddAsync(id);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteCultureAsync(int id)
        {
            var culture = await _context.Kultures.FindAsync(id);
            if (culture != null)
            {
                _context.Kultures.Remove(culture);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateCultureAsync(int id, Culture updatedCulture)
        {
            var culture = await _context.Kultures.FindAsync(id);
            if (culture != null)
            {
                culture.Neme = updatedCulture.Neme; // Обновите другие поля по мере необходимости
                await _context.SaveChangesAsync();
            }
        }
    }
}