using Microsoft.AspNetCore.Mvc;
using AgroProject.Models;
using Microsoft.EntityFrameworkCore;

namespace AgroProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReagentController : ControllerBase
    {
        private readonly AgroDbContext _context;

        public ReagentController(AgroDbContext context)
        {
            _context = context;
        }

        // GET: api/Reagent
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reaktivi>>> GetReagents()
        {
            return await _context.Reaktivis.ToListAsync();
        }

        // GET: api/Reagent/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Reaktivi>> GetReagentById(int id)
        {
            var reagent = await _context.Reaktivis.FindAsync(id);
            if (reagent == null)
            {
                return NotFound();
            }
            return reagent;
        }

        // POST: api/Reagent
        [HttpPost]
        public async Task<ActionResult<Reaktivi>> CreateReagent(Reaktivi reagent)
        {
            _context.Reaktivis.Add(reagent);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetReagentById), new { id = reagent.Id }, reagent);
        }

        // PUT: api/Reagent/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReagent(int id, Reaktivi reagent)
        {
            if (id != reagent.Id)
            {
                return BadRequest();
            }

            _context.Entry(reagent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReagentExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/Reagent/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReagent(int id)
        {
            var reagent = await _context.Reaktivis.FindAsync(id);
            if (reagent == null)
            {
                return NotFound();
            }

            _context.Reaktivis.Remove(reagent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReagentExists(int id)
        {
            return _context.Reaktivis.Any(e => e.Id == id);
        }
    }
}
