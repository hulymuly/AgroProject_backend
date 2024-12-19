using Microsoft.AspNetCore.Mvc;
using AgroProject.Models;
using Microsoft.EntityFrameworkCore;
using AgroProject.Helpers.Validation;
namespace AgroProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EtiketkaController : ControllerBase
    {
        private readonly AgroDbContext _context;

        public EtiketkaController(AgroDbContext context)
        {
            _context = context;
        }

        // GET: api/Etiketka
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Etiketka>>> GetEtiketkas()
        {
            return await _context.Etiketkas.ToListAsync();
        }

        // GET: api/Etiketka/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Etiketka>> GetEtiketka(int id)
        {
            var etiketka = await _context.Etiketkas.FindAsync(id);

            if (etiketka == null)
            {
                return NotFound(new { Error = "Этикетка не найдена." });
            }

            return etiketka;
        }

        // POST: api/Etiketka
        [HttpPost]
        public async Task<ActionResult<Etiketka>> CreateEtiketka([FromBody] Etiketka etiketka)
        {
            if (etiketka == null)
            {
                return BadRequest(new { Error = "Неверные данные для создания этикетки." });
            }

            _context.Etiketkas.Add(etiketka);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEtiketka), new { id = etiketka.Id }, etiketka);
        }

        // PUT: api/Etiketka/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEtiketka(int id, [FromBody] Etiketka etiketka)
        {
            if (id != etiketka.Id)
            {
                return BadRequest(new { Error = "Идентификатор не совпадает." });
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
                    return NotFound(new { Error = "Этикетка не найдена." });
                }
                throw;
            }

            return NoContent();
        }
        

[HttpPost]
public async Task<IActionResult> CreateSample([FromBody] RegistraciaObrazcov sample)
{
    var validationErrors = SampleValidator.ValidateSample(sample);
    if (validationErrors.Count > 0)
    {
        return BadRequest(new { Errors = validationErrors });
    }

    var zakazchik = await _context.Zakazchiks.FindAsync(sample.Zakazchik);
    if (zakazchik == null)
    {
        return BadRequest(new { Error = "Указанный заказчик не найден." });
    }

    _context.RegistraciaObrazcovs.Add(sample);
    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(GetSample), new { id = sample.Id }, sample);
}


        // DELETE: api/Etiketka/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEtiketka(int id)
        {
            var etiketka = await _context.Etiketkas.FindAsync(id);

            if (etiketka == null)
            {
                return NotFound(new { Error = "Этикетка не найдена." });
            }

            _context.Etiketkas.Remove(etiketka);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EtiketkaExists(int id)
        {
            return _context.Etiketkas.Any(e => e.Id == id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSample(int id, [FromBody] RegistraciaObrazcov sample)
        {
            if (id != sample.Id)
            {
                return BadRequest(new { Error = "Идентификатор в пути не совпадает с идентификатором объекта." });
            }
            var validationErrors = SampleValidator.ValidateSample(sample);
            if (validationErrors.Count > 0)
            {
                return BadRequest(new { Errors = validationErrors });
            }
            var zakazchik = await _context.Zakazchiks.FindAsync(sample.Zakazchik);
            if (zakazchik == null)
            {
                return BadRequest(new { Error = "Указанный заказчик не найден." });
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
                    return NotFound(new { Error = "Образец не найден." });
                }
                throw;
            }
            return NoContent();
        }
    }  
}


