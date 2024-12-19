using Microsoft.AspNetCore.Mvc;
using AgroProject.Models;
using AgroProject.DTOs;
using AgroProject.Services;

namespace AgroProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly EquipmentService _equipmentService;

        public EquipmentController(EquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        // Получить все оборудование
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentDto>>> GetAll()
        {
            var equipment = await _equipmentService.GetAllEquipmentAsync();
            return Ok(equipment);
        }

        // Получить оборудование по ID
        [HttpGet("{id}")]
        public async Task<ActionResult<EquipmentDto>> GetById(int id)
        {
            var equipment = await _equipmentService.GetEquipmentByIdAsync(id);
            if (equipment == null)
                return NotFound();

            return Ok(equipment);
        }

        // Добавить новое оборудование
        [HttpPost]
        public async Task<ActionResult> Create(EquipmentDto newEquipment)
        {
            var createdEquipment = await _equipmentService.CreateEquipmentAsync(newEquipment);
            return CreatedAtAction(nameof(GetById), new { id = createdEquipment.Id }, createdEquipment);
        }

        // Обновить оборудование
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, EquipmentDto updatedEquipment)
        {
            var result = await _equipmentService.UpdateEquipmentAsync(id, updatedEquipment);
            if (!result)
                return NotFound();

            return NoContent();
        }

        // Удалить оборудование
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _equipmentService.DeleteEquipmentAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
