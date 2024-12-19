using Microsoft.AspNetCore.Mvc;
using AgroProject.Models;
using Microsoft.EntityFrameworkCore;

namespace AgroProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly AgroDbContext _context;

        public SampleController(AgroDbContext context)
        {
            _context = context;
        }

        // GET: api/Sample
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistraciaObrazcov>>> GetSamples()
        {
            return await _context.RegistraciaObrazcov.ToListAsync();
        }

        // GET: api/Sample/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<RegistraciaObrazcov>> GetSample(int id)
        {
            var sample = await _context.RegistraciaObrazcov.FindAsync(id);

            if (sample == null)
            {
                return NotFound();
            }

            return sample;
        }

        // POST: api/Sample
        [HttpPost]
        public async Task<ActionResult<RegistraciaObrazcov>> CreateSample(RegistraciaObrazcov sample)
        {
            if (sample == null)
            {
                return BadRequest("Sample data is null.");
            }

            _context.RegistraciaObrazcov.Add(sample);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSample), new { id = sample.Id }, sample);
        }

        // PUT: api/Sample/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSample(int id, RegistraciaObrazcov sample)
        {
            if (id != sample.Id)
            {
                return BadRequest("Sample ID mismatch.");
            }

            _context.Entry(sample).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SampleExists(id))
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

        // DELETE: api/Sample/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSample(int id)
        {
            var sample = await _context.RegistraciaObrazcov.FindAsync(id);
            if (sample == null)
            {
                return NotFound();
            }

            _context.RegistraciaObrazcov.Remove(sample);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SampleExists(int id)
        {
            return _context.RegistraciaObrazcov.Any(e => e.Id == id);
        }
    }
}
