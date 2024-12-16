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
    public class ZakazchiksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ZakazchiksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Zakazchiks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zakazchik>>> GetZakazchiks()
        {
            return await _context.Zakazchiks.ToListAsync();
        }

        // GET: api/Zakazchiks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Zakazchik>> GetZakazchik(int id)
        {
            var zakazchik = await _context.Zakazchiks.FindAsync(id);

            if (zakazchik == null)
            {
                return NotFound();
            }

            return zakazchik;
        }

        // PUT: api/Zakazchiks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutZakazchik(int id, Zakazchik zakazchik)
        {
            if (id != zakazchik.Id)
            {
                return BadRequest();
            }

            _context.Entry(zakazchik).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZakazchikExists(id))
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

        // POST: api/Zakazchiks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Zakazchik>> PostZakazchik(Zakazchik zakazchik)
        {
            _context.Zakazchiks.Add(zakazchik);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetZakazchik", new { id = zakazchik.Id }, zakazchik);
        }

        // DELETE: api/Zakazchiks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZakazchik(int id)
        {
            var zakazchik = await _context.Zakazchiks.FindAsync(id);
            if (zakazchik == null)
            {
                return NotFound();
            }

            _context.Zakazchiks.Remove(zakazchik);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ZakazchikExists(int id)
        {
            return _context.Zakazchiks.Any(e => e.Id == id);
        }
    }
}
