using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.Models.Entitites;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly SqlDbContext _context;

        public CustomersController(SqlDbContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerModel>>> GetCustomers()
        {
            var items = new List<CustomerModel>();
            foreach (var item in await _context.Customers.ToListAsync())
                items.Add(new CustomerModel(item.Id, item.FirstName, item.LastName, item.Email));

            return items;
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerModel>> GetCustomerEntity(int id)
        {
            var customerEntity = await _context.Customers.FindAsync(id);

            if (customerEntity == null)
            {
                return NotFound();
            }

            return new CustomerModel(customerEntity.Id, customerEntity.FirstName, customerEntity.LastName, customerEntity.Email);
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerEntity(int id, CustomerModel customerModel)
        {
            if (id != customerModel.Id)
            {
                return BadRequest();
            }

            var customerEntity = await _context.Customers.FindAsync(customerModel.Id);
            customerEntity.FirstName = customerModel.FirstName;
            customerEntity.LastName = customerModel.LastName;   
            customerEntity.Email = customerModel.Email;

            _context.Entry(customerEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerEntityExists(id))
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

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerModel>> PostCustomerEntity(CustomerModel customerModel)
        {
            if (await _context.Customers.AnyAsync(x => x.Email == customerModel.Email))
                return Conflict();

            var customerEntity = new CustomerEntity(customerModel.FirstName, customerModel.LastName, customerModel.Email);

            _context.Customers.Add(customerEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerEntity", new { id = customerEntity.Id }, new CustomerModel(customerEntity.Id, customerEntity.FirstName, customerEntity.LastName, customerEntity.Email));
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerEntity(int id)
        {
            var customerEntity = await _context.Customers.FindAsync(id);
            if (customerEntity == null)
            {
                return NotFound();
            }

            customerEntity.FirstName = "";
            customerEntity.LastName = "";
            customerEntity.Email = "";

            _context.Entry(customerEntity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerEntityExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}
