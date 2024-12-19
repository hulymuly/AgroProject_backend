using AgroProject.Models;
using Microsoft.EntityFrameworkCore;

namespace AgroProject.Repositories
{
    public interface ICultureRepository
    {
        Task<IEnumerable<Kulture>> GetAllAsync();
        Task<Kulture> AddAsync(Kulture culture);
    }

    public class CultureRepository : ICultureRepository
    {
        private readonly AgroDbContext _context;

        public CultureRepository(AgroDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Kulture>> GetAllAsync()
        {
            return await _context.Kultures.ToListAsync();
        }

        public async Task<Kulture> AddAsync(Kulture culture)
        {
            _context.Kultures.Add(culture);
            await _context.SaveChangesAsync();
            return culture;
        }
    }
}
