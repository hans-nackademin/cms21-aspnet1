﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Exercise_4;
using Exercise_4.Models.Entities;

namespace Exercise_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly SqlDbContext _context;

        public AddressesController(SqlDbContext context)
        {
            _context = context;
        }

        // GET: api/Addresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressEntity>>> GetAddresses()
        {
            return await _context.Addresses.ToListAsync();
        }

        // GET: api/Addresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddressEntity>> GetAddressEntity(int id)
        {
            var addressEntity = await _context.Addresses.FindAsync(id);

            if (addressEntity == null)
            {
                return NotFound();
            }

            return addressEntity;
        }

        // PUT: api/Addresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddressEntity(int id, AddressEntity addressEntity)
        {
            if (id != addressEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(addressEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressEntityExists(id))
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

        // POST: api/Addresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AddressEntity>> PostAddressEntity(AddressEntity addressEntity)
        {
            _context.Addresses.Add(addressEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddressEntity", new { id = addressEntity.Id }, addressEntity);
        }

        // DELETE: api/Addresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddressEntity(int id)
        {
            var addressEntity = await _context.Addresses.FindAsync(id);
            if (addressEntity == null)
            {
                return NotFound();
            }

            _context.Addresses.Remove(addressEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AddressEntityExists(int id)
        {
            return _context.Addresses.Any(e => e.Id == id);
        }
    }
}
