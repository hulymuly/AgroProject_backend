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
    public class RegistraciaObrazcovsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RegistraciaObrazcovsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/RegistraciaObrazcovs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistraciaObrazcov>>> GetRegistraciaObrazcovs()
        {
            return await _context.RegistraciaObrazcovs.ToListAsync();
        }

        // GET: api/RegistraciaObrazcovs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegistraciaObrazcov>> GetRegistraciaObrazcov(int id)
        {
            var registraciaObrazcov = await _context.RegistraciaObrazcovs.FindAsync(id);

            if (registraciaObrazcov == null)
            {
                return NotFound();
            }

            return registraciaObrazcov;
        }

        // PUT: api/RegistraciaObrazcovs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistraciaObrazcov(int id, RegistraciaObrazcov registraciaObrazcov)
        {
            if (id != registraciaObrazcov.Id)
            {
                return BadRequest();
            }

            _context.Entry(registraciaObrazcov).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistraciaObrazcovExists(id))
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

        // POST: api/RegistraciaObrazcovs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RegistraciaObrazcov>> PostRegistraciaObrazcov(RegistraciaObrazcov registraciaObrazcov)
        {
            _context.RegistraciaObrazcovs.Add(registraciaObrazcov);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegistraciaObrazcov", new { id = registraciaObrazcov.Id }, registraciaObrazcov);
        }

        // DELETE: api/RegistraciaObrazcovs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistraciaObrazcov(int id)
        {
            var registraciaObrazcov = await _context.RegistraciaObrazcovs.FindAsync(id);
            if (registraciaObrazcov == null)
            {
                return NotFound();
            }

            _context.RegistraciaObrazcovs.Remove(registraciaObrazcov);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegistraciaObrazcovExists(int id)
        {
            return _context.RegistraciaObrazcovs.Any(e => e.Id == id);
        }
    }
}
