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
    public class ProtokolsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProtokolsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Protokols
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Protokol>>> GetProtokols()
        {
            return await _context.Protokols.ToListAsync();
        }

        // GET: api/Protokols/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Protokol>> GetProtokol(int id)
        {
            var protokol = await _context.Protokols.FindAsync(id);

            if (protokol == null)
            {
                return NotFound();
            }

            return protokol;
        }

        // PUT: api/Protokols/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProtokol(int id, Protokol protokol)
        {
            if (id != protokol.Id)
            {
                return BadRequest();
            }

            _context.Entry(protokol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProtokolExists(id))
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

        // POST: api/Protokols
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Protokol>> PostProtokol(Protokol protokol)
        {
            _context.Protokols.Add(protokol);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProtokol", new { id = protokol.Id }, protokol);
        }

        // DELETE: api/Protokols/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProtokol(int id)
        {
            var protokol = await _context.Protokols.FindAsync(id);
            if (protokol == null)
            {
                return NotFound();
            }

            _context.Protokols.Remove(protokol);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProtokolExists(int id)
        {
            return _context.Protokols.Any(e => e.Id == id);
        }
    }
}
