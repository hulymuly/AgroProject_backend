using AgroProject.Models;
using AgroProject.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgroProject.Services
{
    public interface IEquipmentService
    {
        Task<IEnumerable<Oborudovanie>> GetAllEquipmentAsync();
        Task<Oborudovanie> GetEquipmentByIdAsync(int id);
        Task AddEquipmentAsync(Oborudovanie equipment);
        Task UpdateEquipmentAsync(int id, Oborudovanie updatedEquipment);
        Task DeleteEquipmentAsync(int id);
        Task<IEnumerable<Oborudovanie>> CheckExpiringEquipmentAsync();
        Task<IEnumerable<AuditLog>> GetEquipmentAuditAsync();
    }

    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public EquipmentService(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public async Task<IEnumerable<Oborudovanie>> GetAllEquipmentAsync()
        {
            return await _equipmentRepository.GetAllEquipmentAsync();
        }

        public async Task<Oborudovanie> GetEquipmentByIdAsync(int id)
        {
            return await _equipmentRepository.GetEquipmentByIdAsync(id);
        }

        public async Task AddEquipmentAsync(Oborudovanie equipment)
        {
            await _equipmentRepository.AddEquipmentAsync(equipment);
        }

        public async Task UpdateEquipmentAsync(int id, Oborudovanie updatedEquipment)
        {
            await _equipmentRepository.UpdateEquipmentAsync(id, updatedEquipment);
        }

        public async Task DeleteEquipmentAsync(int id)
        {
            await _equipmentRepository.DeleteEquipmentAsync(id);
        }

        public async Task<IEnumerable<Oborudovanie>> CheckExpiringEquipmentAsync()
        {
            return await _equipmentRepository.GetExpiringEquipmentAsync();
               public async Task<IEnumerable<AuditLog>> GetEquipmentAuditAsync()
        {
            return await _equipmentRepository.GetEquipmentAuditAsync();
        }
    }
}