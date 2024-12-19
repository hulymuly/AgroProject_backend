using Microsoft.AspNetCore.Mvc;
using AgroProject.Models;
using Microsoft.EntityFrameworkCore;

namespace AgroProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly AgroDbContext _context;

        public OrdersController(AgroDbContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistraciaObrazcov>>> GetOrders()
        {
            return await _context.RegistraciaObrazcovs.ToListAsync();
        }

        // GET: api/Orders/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<RegistraciaObrazcov>> GetOrderById(int id)
        {
            var order = await _context.RegistraciaObrazcovs.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult<RegistraciaObrazcov>> CreateOrder(RegistraciaObrazcov order)
        {
            _context.RegistraciaObrazcovs.Add(order);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);
        }

        // PUT: api/Orders/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, RegistraciaObrazcov order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/Orders/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.RegistraciaObrazcovs.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.RegistraciaObrazcovs.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return _context.RegistraciaObrazcovs.Any(e => e.Id == id);
        }
    }
}
