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
    public class ReaktivPrixodsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReaktivPrixodsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ReaktivPrixods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReaktivPrixod>>> GetReaktivPrixods()
        {
            return await _context.ReaktivPrixods.ToListAsync();
        }

        // POST: api/ReaktivPrixods
        [HttpPost]
        public async Task<ActionResult<ReaktivPrixod>> AddReaktivPrixod(ReaktivPrixod model)
        {
            if (model == null)
            {
                return BadRequest("Данные для прихода не заполнены.");
            }

            _context.ReaktivPrixods.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReaktivPrixods), new { id = model.Id }, model);
        }

        // GET: api/ReaktivPrixods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReaktivPrixod>> GetReaktivPrixod(int id)
        {
            var reaktivPrixod = await _context.ReaktivPrixods.FindAsync(id);

            if (reaktivPrixod == null)
            {
                return NotFound("Запись о приходе не найдена.");
            }

            return reaktivPrixod;
        }
    }
}