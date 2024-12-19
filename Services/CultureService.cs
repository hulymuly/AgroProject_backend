using AgroProject.Models;

namespace AgroProject.Services
{
    public interface ICultureService
    {
        Task<IEnumerable<Kulture>> GetAllCulturesAsync();
        Task<Kulture> AddCultureAsync(Kulture culture);
    }

    public class CultureService : ICultureService
    {
        private readonly ICultureRepository _cultureRepository;

        public CultureService(ICultureRepository cultureRepository)
        {
            _cultureRepository = cultureRepository;
        }

        public async Task<IEnumerable<Kulture>> GetAllCulturesAsync()
        {
            return await _cultureRepository.GetAllAsync();
        }

        public async Task<Kulture> AddCultureAsync(Kulture culture)
        {
            return await _cultureRepository.AddAsync(culture);
        }
    }
}
