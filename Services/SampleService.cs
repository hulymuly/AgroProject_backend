using AgroProject.Models;
using AgroProject.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgroProject.Services
{
    public interface ISampleService
    {
        Task<IEnumerable<RegistraciaObrazcov>> GetAllSamplesAsync();
        Task<RegistraciaObrazcov> GetSampleByIdAsync(int id);
        Task AddSampleAsync(RegistraciaObrazcov sample);
        Task UpdateSampleAsync(int id, RegistraciaObrazcov updatedSample);
        Task DeleteSampleAsync(int id);
        Task<string> GenerateLabelForSampleAsync(int id);
    }

    public class SampleService : ISampleService
    {
        private readonly ISampleRepository _sampleRepository;

        public SampleService(ISampleRepository sampleRepository)
        {
            _sampleRepository = sampleRepository;
        }

        public async Task<IEnumerable<RegistraciaObrazcov>> GetAllSamplesAsync()
        {
            return await _sampleRepository.GetAllSamplesAsync();
        }

        public async Task<RegistraciaObrazcov> GetSampleByIdAsync(int id)
        {
            return await _sampleRepository.GetSampleByIdAsync(id);
        }

        public async Task AddSampleAsync(RegistraciaObrazcov sample)
        {
            await _sampleRepository.AddSampleAsync(sample);
        }

        public async Task UpdateSampleAsync(int id, RegistraciaObrazcov updatedSample)
        {
            await _sampleRepository.UpdateSampleAsync(id, updatedSample);
        }

        public async Task DeleteSampleAsync(int id)
        {
            await _sampleRepository.DeleteSampleAsync(id);
        }

        public async Task<string> GenerateLabelForSampleAsync(int id)
        {
            // Логика для генерации этикетки для образца
            return await _sampleRepository.GenerateLabelForSampleAsync(id);
        }
    }
}