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
    public class GostsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GostsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Gosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gost>>> GetGosts()
        {
            return await _context.Gosts.ToListAsync();
        }

        // GET: api/Gosts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gost>> GetGost(int id)
        {
            var gost = await _context.Gosts.FindAsync(id);

            if (gost == null)
            {
                return NotFound();
            }

            return gost;
        }

        // PUT: api/Gosts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGost(int id, Gost gost)
        {
            if (id != gost.Id)
            {
                return BadRequest();
            }

            _context.Entry(gost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GostExists(id))
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

        // POST: api/Gosts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Gost>> PostGost(Gost gost)
        {
            _context.Gosts.Add(gost);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGost", new { id = gost.Id }, gost);
        }

        // DELETE: api/Gosts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGost(int id)
        {
            var gost = await _context.Gosts.FindAsync(id);
            if (gost == null)
            {
                return NotFound();
            }

            _context.Gosts.Remove(gost);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GostExists(int id)
        {
            return _context.Gosts.Any(e => e.Id == id);
        }
    }
}
