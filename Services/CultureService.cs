using AgroProject.Models;
using AgroProject.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgroProject.Services
{
    public interface ICultureService
    {
        Task<IEnumerable<Culture>> GetAllCulturesAsync();
        Task<Culture> GetCultureByIdAsync(int id);
        Task AddCultureAsync(Culture culture);
        Task UpdateCultureAsync(int id, Culture updatedCulture);
        Task DeleteCultureAsync(int id);
    }

    public class CultureService : ICultureService
    {
        private readonly ICultureRepository _cultureRepository;

        public CultureService(ICultureRepository cultureRepository)
        {
            _cultureRepository = cultureRepository;
        }

        public async Task<IEnumerable<Culture>> GetAllCulturesAsync()
        {
            return await _cultureRepository.GetAllCulturesAsync();
        }

        public async Task<Culture> GetCultureByIdAsync(int id)
        {
            return await _cultureRepository.GetCultureByIdAsync(id);
        }

        public async Task AddCultureAsync(Culture culture)
        {
            await _cultureRepository.AddCultureAsync(culture);
        }

        public async Task UpdateCultureAsync(int id, Culture updatedCulture)
        {
            await _cultureRepository.UpdateCultureAsync(id, updatedCulture);
        }

        public async Task DeleteCultureAsync(int id)
        {
            await _cultureRepository.DeleteCultureAsync(id);
        }
    }
}