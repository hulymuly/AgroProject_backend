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
    public class SessiumsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SessiumsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Sessiums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sessium>>> GetSessia()
        {
            return await _context.Sessia.ToListAsync();
        }

        // GET: api/Sessiums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sessium>> GetSessium(int id)
        {
            var sessium = await _context.Sessia.FindAsync(id);

            if (sessium == null)
            {
                return NotFound();
            }

            return sessium;
        }

        // PUT: api/Sessiums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSessium(int id, Sessium sessium)
        {
            if (id != sessium.Id)
            {
                return BadRequest();
            }

            _context.Entry(sessium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SessiumExists(id))
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

        // POST: api/Sessiums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sessium>> PostSessium(Sessium sessium)
        {
            _context.Sessia.Add(sessium);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSessium", new { id = sessium.Id }, sessium);
        }

        // DELETE: api/Sessiums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSessium(int id)
        {
            var sessium = await _context.Sessia.FindAsync(id);
            if (sessium == null)
            {
                return NotFound();
            }

            _context.Sessia.Remove(sessium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SessiumExists(int id)
        {
            return _context.Sessia.Any(e => e.Id == id);
        }
    }
}
