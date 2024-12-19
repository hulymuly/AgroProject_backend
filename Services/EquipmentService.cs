using AgroProject.Models;
using AgroProject.DTOs;
using Microsoft.EntityFrameworkCore;

namespace AgroProject.Services
{
    public class EquipmentService
    {
        private readonly AgroDbContext _dbContext;

        public EquipmentService(AgroDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Получить все оборудование
        public async Task<IEnumerable<EquipmentDto>> GetAllEquipmentAsync()
        {
            return await _dbContext.Oborudovanie
                .Select(e => new EquipmentDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    Kategoria = e.Kategoria,
                    Model = e.Model,
                    NomerInvent = e.NomerInvent,
                    NomerZavod = e.NomerZavod,
                    DataVvodaVExpluataciu = e.DataVvodaVExpluataciu.HasValue ? e.DataVvodaVExpluataciu.Value.ToDateTime(TimeOnly.MinValue) : null,
                    NomerSvidetelstva = e.NomerSvidetelstva,
                    DataProverki = e.DataProverki.HasValue ? e.DataProverki.Value.ToDateTime(TimeOnly.MinValue) : null,
                    GodenDo = e.GodenDo.HasValue ? e.GodenDo.Value.ToDateTime(TimeOnly.MinValue) : null,
                    Diametr = e.Diametr,
                    Dlinna = e.Dlinna,
                    Visota = e.Visota,
                    Glubina = e.Glubina,
                    Shirina = e.Shirina,
                    DataVivodaIzIspolz = e.DataVivodaIzIspolz.HasValue ? e.DataVivodaIzIspolz.Value.ToDateTime(TimeOnly.MinValue) : null
                })
                .ToListAsync();
        }

        // Получить оборудование по ID
        public async Task<EquipmentDto?> GetEquipmentByIdAsync(int id)
        {
            var equipment = await _dbContext.Oborudovanie.FindAsync(id);
            if (equipment == null) return null;

            return new EquipmentDto
            {
                Id = equipment.Id,
                Name = equipment.Name,
                Kategoria = equipment.Kategoria,
                Model = equipment.Model,
                NomerInvent = equipment.NomerInvent,
                NomerZavod = equipment.NomerZavod,
                DataVvodaVExpluataciu = equipment.DataVvodaVExpluataciu.HasValue ? equipment.DataVvodaVExpluataciu.Value.ToDateTime(TimeOnly.MinValue) : null,
                NomerSvidetelstva = equipment.NomerSvidetelstva,
                DataProverki = equipment.DataProverki.HasValue ? equipment.DataProverki.Value.ToDateTime(TimeOnly.MinValue) : null,
                GodenDo = equipment.GodenDo.HasValue ? equipment.GodenDo.Value.ToDateTime(TimeOnly.MinValue) : null,
                Diametr = equipment.Diametr,
                Dlinna = equipment.Dlinna,
                Visota = equipment.Visota,
                Glubina = equipment.Glubina,
                Shirina = equipment.Shirina,
                DataVivodaIzIspolz = equipment.DataVivodaIzIspolz.HasValue ? equipment.DataVivodaIzIspolz.Value.ToDateTime(TimeOnly.MinValue) : null
            };
        }

        // Добавить новое оборудование
        public async Task<EquipmentDto> CreateEquipmentAsync(EquipmentDto newEquipment)
        {
            var equipment = new Oborudovanie
            {
                Name = newEquipment.Name,
                Kategoria = newEquipment.Kategoria,
                Model = newEquipment.Model,
                NomerInvent = newEquipment.NomerInvent,
                NomerZavod = newEquipment.NomerZavod,
                DataVvodaVExpluataciu = newEquipment.DataVvodaVExpluataciu.HasValue ? DateOnly.FromDateTime(newEquipment.DataVvodaVExpluataciu.Value) : null,
                NomerSvidetelstva = newEquipment.NomerSvidetelstva,
                DataProverki = newEquipment.DataProverki.HasValue ? DateOnly.FromDateTime(newEquipment.DataProverki.Value) : null,
                GodenDo = newEquipment.GodenDo.HasValue ? DateOnly.FromDateTime(newEquipment.GodenDo.Value) : null,
                Diametr = newEquipment.Diametr,
                Dlinna = newEquipment.Dlinna,
                Visota = newEquipment.Visota,
                Glubina = newEquipment.Glubina,
                Shirina = newEquipment.Shirina,
                DataVivodaIzIspolz = newEquipment.DataVivodaIzIspolz.HasValue ? DateOnly.FromDateTime(newEquipment.DataVivodaIzIspolz.Value) : null
            };

            _dbContext.Oborudovanie.Add(equipment);
            await _dbContext.SaveChangesAsync();

            newEquipment.Id = equipment.Id;
            return newEquipment;
        }

        // Обновить оборудование
        public async Task<bool> UpdateEquipmentAsync(int id, EquipmentDto updatedEquipment)
        {
            var equipment = await _dbContext.Oborudovanie.FindAsync(id);
            if (equipment == null) return false;

            equipment.Name = updatedEquipment.Name;
            equipment.Kategoria = updatedEquipment.Kategoria;
            equipment.Model = updatedEquipment.Model;
            equipment.NomerInvent = updatedEquipment.NomerInvent;
            equipment.NomerZavod = updatedEquipment.NomerZavod;
            equipment.DataVvodaVExpluataciu = updatedEquipment.DataVvodaVExpluataciu.HasValue ? DateOnly.FromDateTime(updatedEquipment.DataVvodaVExpluataciu.Value) : null;
            equipment.NomerSvidetelstva = updatedEquipment.NomerSvidetelstva;
            equipment.DataProverki = updatedEquipment.DataProverki.HasValue ? DateOnly.FromDateTime(updatedEquipment.DataProverki.Value) : null;
            equipment.GodenDo = updatedEquipment.GodenDo.HasValue ? DateOnly.FromDateTime(updatedEquipment.GodenDo.Value) : null;
            equipment.Diametr = updatedEquipment.Diametr;
            equipment.Dlinna = updatedEquipment.Dlinna;
            equipment.Visota = updatedEquipment.Visota;
            equipment.Glubina = updatedEquipment.Glubina;
            equipment.Shirina = updatedEquipment.Shirina;
            equipment.DataVivodaIzIspolz = updatedEquipment.DataVivodaIzIspolz.HasValue ? DateOnly.FromDateTime(updatedEquipment.DataVivodaIzIspolz.Value) : null;

            _dbContext.Oborudovanie.Update(equipment);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        // Удалить оборудование
        public async Task<bool> DeleteEquipmentAsync(int id)
        {
            var equipment = await _dbContext.Oborudovanie.FindAsync(id);
            if (equipment == null) return false;

            _dbContext.Oborudovanie.Remove(equipment);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
