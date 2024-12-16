using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgroProject.Data;
using AgroProject.Models;

namespace AgroProject.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class KulturesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public KulturesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Kultures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kulture>>> GetKultures()
        {
            return await _context.Kultures.ToListAsync();
        }

        // GET: api/Kultures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kulture>> GetKulture(int id)
        {
            var kulture = await _context.Kultures.FindAsync(id);

            if (kulture == null)
            {
                return NotFound();
            }

            return kulture;
        }

        // PUT: api/Kultures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKulture(int id, Kulture kulture)
        {
            if (id != kulture.Id)
            {
                return BadRequest();
            }

            _context.Entry(kulture).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KultureExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Kultures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Kulture>> PostKulture(Kulture kulture)
        {
            _context.Kultures.Add(kulture);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKulture", new { id = kulture.Id }, kulture);
        }

        // DELETE: api/Kultures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKulture(int id)
        {
            var kulture = await _context.Kultures.FindAsync(id);
            if (kulture == null)
            {
                return NotFound();
            }

            _context.Kultures.Remove(kulture);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KultureExists(int id)
        {
            return _context.Kultures.Any(e => e.Id == id);
        }
    }
}
