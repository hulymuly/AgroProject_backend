using AgroProject.Data;
using AgroProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgroProject.Repositories
{
    public interface IEquipmentRepository
    {
        Task<IEnumerable<Oborudovanie>> GetAllEquipmentAsync();
        Task<Oborudovanie> GetEquipmentByIdAsync(int id);
        Task AddEquipmentAsync(Oborudovanie equipment);
        Task UpdateEquipmentAsync(int id, Oborudovanie updatedEquipment);
        Task DeleteEquipmentAsync(int id);
        Task<IEnumerable<Oborudovanie>> GetEquipmentByCategoryAsync(string category);
    }

    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly AppDbContext _context;

        public EquipmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Oborudovanie>> GetAllEquipmentAsync()
        {
            return await _context.Oborudovanies.ToListAsync();
        }

        public async Task<Oborudovanie> GetEquipmentByIdAsync(int id)
        {
            return await _context.Oborudovanies.FindAsync(id);
        }

        public async Task AddEquipmentAsync(Oborudovanie equipment)
        {
            await _context.Oborudovanies.AddAsync(equipment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEquipmentAsync(int id, Oborudovanie updatedEquipment)
        {
            var equipment = await _context.Oborudovanies.FindAsync(id);
            if (equipment != null)
            {
                equipment.Name = updatedEquipment.Name; // Обновите другие поля по мере необходимости
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteEquipmentAsync(int id)
        {
            var equipment = await _context.Oborudovanies.FindAsync(id);
            if (equipment != null)
            {
                _context.Oborudovanies.Remove(equipment);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Oborudovanie>> GetEquipmentByCategoryAsync(string category)
        {
            return await _context.Oborudovanies.Where(e => e.Kategoria == category).ToListAsync();
        }
    }
}