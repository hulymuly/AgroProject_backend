using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgroProject.Data;
using AgroProject.Models;

namespace AgroProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReaktiviRasxodsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReaktiviRasxodsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ReaktiviRasxods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReaktiviRasxod>>> GetReaktiviRasxods()
        {
            return await _context.ReaktiviRasxods.ToListAsync();
        }

        // POST: api/ReaktiviRasxods
        [HttpPost]
        public async Task<ActionResult<ReaktiviRasxod>> AddReaktiviRasxod(ReaktiviRasxod model)
        {
            if (model == null)
            {
                return BadRequest("Данные для расхода не заполнены.");
            }

            var reagent = await _context.Reaktivis.FindAsync(model.Reaktiv);
            if (reagent == null)
            {
                return NotFound("Реагент не найден.");
            }

            // Проверяем доступное количество
            if (int.TryParse(model.IzrasxodKolvo, out int usedQuantity) && reagent.Quantity < usedQuantity)
            {
                return BadRequest("Недостаточное количество реагента на складе.");
            }

            // Обновляем количество в основной таблице
            reagent.Quantity -= usedQuantity;

            _context.ReaktiviRasxods.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReaktiviRasxods), new { id = model.Id }, model);
        }

        // GET: api/ReaktiviRasxods/analyze-usage
        [HttpGet("analyze-usage")]
        public async Task<ActionResult<IEnumerable<object>>> AnalyzeUsage([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var usage = await _context.ReaktiviRasxods
                .Where(r => r.Data >= DateOnly.FromDateTime(startDate) && r.Data <= DateOnly.FromDateTime(endDate))
                .Select(r => new
                {
                    ReagentId = r.Reaktiv,
                    UsedQuantity = r.IzrasxodKolvo,
                    UsageDate = r.Data,
                    MethodGost = r.MetodikaGost
                })
                .ToListAsync();

            return Ok(usage);
        }
    }
}