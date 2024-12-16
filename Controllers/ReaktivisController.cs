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
    public class ReaktivisController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReaktivisController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Reaktivis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reaktivi>>> GetReaktivis()
        {
            return await _context.Reaktivis.ToListAsync();
        }

        // GET: api/Reaktivis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reaktivi>> GetReaktivi(int id)
        {
            var reaktivi = await _context.Reaktivis.FindAsync(id);

            if (reaktivi == null)
            {
                return NotFound();
            }

            return reaktivi;
        }

        // PUT: api/Reaktivis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReaktivi(int id, Reaktivi reaktivi)
        {
            if (id != reaktivi.Id)
            {
                return BadRequest();
            }

            _context.Entry(reaktivi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReaktiviExists(id))
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

        // POST: api/Reaktivis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reaktivi>> PostReaktivi(Reaktivi reaktivi)
        {
            _context.Reaktivis.Add(reaktivi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReaktivi", new { id = reaktivi.Id }, reaktivi);
        }

        // DELETE: api/Reaktivis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReaktivi(int id)
        {
            var reaktivi = await _context.Reaktivis.FindAsync(id);
            if (reaktivi == null)
            {
                return NotFound();
            }

            _context.Reaktivis.Remove(reaktivi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReaktiviExists(int id)
        {
            return _context.Reaktivis.Any(e => e.Id == id);
        }
    }
}
