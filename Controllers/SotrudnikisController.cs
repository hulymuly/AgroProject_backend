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
    public class SotrudnikisController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SotrudnikisController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Sotrudnikis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sotrudniki>>> GetSotrudnikis()
        {
            return await _context.Sotrudnikis.ToListAsync();
        }

        // GET: api/Sotrudnikis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sotrudniki>> GetSotrudniki(int id)
        {
            var sotrudniki = await _context.Sotrudnikis.FindAsync(id);

            if (sotrudniki == null)
            {
                return NotFound();
            }

            return sotrudniki;
        }

        // PUT: api/Sotrudnikis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSotrudniki(int id, Sotrudniki sotrudniki)
        {
            if (id != sotrudniki.Id)
            {
                return BadRequest();
            }

            _context.Entry(sotrudniki).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SotrudnikiExists(id))
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

        // POST: api/Sotrudnikis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sotrudniki>> PostSotrudniki(Sotrudniki sotrudniki)
        {
            _context.Sotrudnikis.Add(sotrudniki);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSotrudniki", new { id = sotrudniki.Id }, sotrudniki);
        }

        // DELETE: api/Sotrudnikis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSotrudniki(int id)
        {
            var sotrudniki = await _context.Sotrudnikis.FindAsync(id);
            if (sotrudniki == null)
            {
                return NotFound();
            }

            _context.Sotrudnikis.Remove(sotrudniki);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SotrudnikiExists(int id)
        {
            return _context.Sotrudnikis.Any(e => e.Id == id);
        }
    }
}
