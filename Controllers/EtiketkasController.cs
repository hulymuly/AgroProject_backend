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
    public class EtiketkasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EtiketkasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Etiketkas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Etiketka>>> GetEtiketkas()
        {
            return await _context.Etiketkas.ToListAsync();
        }

        // GET: api/Etiketkas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Etiketka>> GetEtiketka(int id)
        {
            var etiketka = await _context.Etiketkas.FindAsync(id);

            if (etiketka == null)
            {
                return NotFound();
            }

            return etiketka;
        }

        // PUT: api/Etiketkas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEtiketka(int id, Etiketka etiketka)
        {
            if (id != etiketka.Id)
            {
                return BadRequest();
            }

            _context.Entry(etiketka).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EtiketkaExists(id))
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

        // POST: api/Etiketkas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Etiketka>> PostEtiketka(Etiketka etiketka)
        {
            _context.Etiketkas.Add(etiketka);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEtiketka", new { id = etiketka.Id }, etiketka);
        }

        // DELETE: api/Etiketkas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEtiketka(int id)
        {
            var etiketka = await _context.Etiketkas.FindAsync(id);
            if (etiketka == null)
            {
                return NotFound();
            }

            _context.Etiketkas.Remove(etiketka);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EtiketkaExists(int id)
        {
            return _context.Etiketkas.Any(e => e.Id == id);
        }
    }
}
