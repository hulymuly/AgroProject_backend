using AgroProject.Data;
using AgroProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgroProject.Repositories
{
    public interface ISampleRepository
    {
        Task<IEnumerable<RegistraciaObrazcov>> GetAllSamplesAsync();
        Task<RegistraciaObrazcov> GetSampleByIdAsync(int id);
        Task AddSampleAsync(RegistraciaObrazcov sample);
        Task UpdateSampleAsync(int id, RegistraciaObrazcov updatedSample);
        Task DeleteSampleAsync(int id);
        Task<IEnumerable<RegistraciaObrazcov>> GetSamplesByCultureAsync(string culture);
    }

    public class SampleRepository : ISampleRepository
    {
        private readonly AppDbContext _context;

        public SampleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RegistraciaObrazcov>> GetAllSamplesAsync()
        {
            return await _context.RegistraciaObrazcovs.ToListAsync();
        }

        public async Task<RegistraciaObrazcov> GetSampleByIdAsync(int id)
        {
            return await _context.RegistraciaObrazcovs.FindAsync(id);
        }

        public async Task AddSampleAsync(RegistraciaObrazcov sample)
        {
            await _context.RegistraciaObrazcovs.AddAsync(sample);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSampleAsync(int id, RegistraciaObrazcov updatedSample)
        {
            var sample = await _context.RegistraciaObrazcovs.FindAsync(id);
            if (sample != null)
            {
                sample.Kulture = updatedSample.Kulture; // Обновите другие поля по мере необходимости
                sample.Sort = updatedSample.Sort;
                // и так далее для других полей...
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteSampleAsync(int id)
        {
            var sample = await _context.RegistraciaObrazcovs.FindAsync(id);
            if (sample != null)
            {
                _context.RegistraciaObrazcovs.Remove(sample);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<RegistraciaObrazcov>> GetSamplesByCultureAsync(string culture)
        {
            return await _context.RegistraciaObrazcovs
                .Where(s => s.Kulture == culture)
                .ToListAsync();
        }
    }
}