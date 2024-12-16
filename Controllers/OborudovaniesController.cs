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
    public class OborudovaniesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OborudovaniesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Oborudovanies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Oborudovanie>>> GetOborudovanies()
        {
            return await _context.Oborudovanies.ToListAsync();
        }

        // GET: api/Oborudovanies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Oborudovanie>> GetOborudovanie(int id)
        {
            var oborudovanie = await _context.Oborudovanies.FindAsync(id);

            if (oborudovanie == null)
            {
                return NotFound();
            }

            return oborudovanie;
        }

        // PUT: api/Oborudovanies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOborudovanie(int id, Oborudovanie oborudovanie)
        {
            if (id != oborudovanie.Id)
            {
                return BadRequest();
            }

            _context.Entry(oborudovanie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OborudovanieExists(id))
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

        // POST: api/Oborudovanies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Oborudovanie>> PostOborudovanie(Oborudovanie oborudovanie)
        {
            _context.Oborudovanies.Add(oborudovanie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOborudovanie", new { id = oborudovanie.Id }, oborudovanie);
        }

        // DELETE: api/Oborudovanies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOborudovanie(int id)
        {
            var oborudovanie = await _context.Oborudovanies.FindAsync(id);
            if (oborudovanie == null)
            {
                return NotFound();
            }

            _context.Oborudovanies.Remove(oborudovanie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OborudovanieExists(int id)
        {
            return _context.Oborudovanies.Any(e => e.Id == id);
        }
    }
}
