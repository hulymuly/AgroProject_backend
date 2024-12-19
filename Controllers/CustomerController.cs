using Microsoft.AspNetCore.Mvc;
using AgroProject.Models;
using Microsoft.EntityFrameworkCore;

namespace AgroProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly AgroDbContext _context;

        public CustomerController(AgroDbContext context)
        {
            _context = context;
        }

        // GET: api/Customer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zakazchik>>> GetCustomers()
        {
            return await _context.Zakazchiks.ToListAsync();
        }

        // GET: api/Customer/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Zakazchik>> GetCustomerById(int id)
        {
            var customer = await _context.Zakazchiks.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return customer;
        }

        // POST: api/Customer
        [HttpPost]
        public async Task<ActionResult<Zakazchik>> CreateCustomer(Zakazchik customer)
        {
            _context.Zakazchiks.Add(customer);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);
        }

        // PUT: api/Customer/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, Zakazchik customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/Customer/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Zakazchiks.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Zakazchiks.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return _context.Zakazchiks.Any(e => e.Id == id);
        }
    }
}
