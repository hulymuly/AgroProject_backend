using AgroProject.Models;
using AgroProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace AgroProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CultureController : ControllerBase
    {
        private readonly ICultureService _cultureService;

        public CultureController(ICultureService cultureService)
        {
            _cultureService = cultureService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCultures()
        {
            var cultures = await _cultureService.GetAllCulturesAsync();
            return Ok(cultures);
        }

        [HttpPost]
        public async Task<IActionResult> AddCulture([FromBody] Kulture culture)
        {
            if (culture == null || string.IsNullOrWhiteSpace(culture.Neme))
            {
                return BadRequest("Invalid culture data.");
            }

            var result = await _cultureService.AddCultureAsync(culture);
            return CreatedAtAction(nameof(GetAllCultures), new { id = result.Id }, result);
        }
    }
}
