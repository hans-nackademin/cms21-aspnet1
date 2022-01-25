#nullable disable
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
    public class HandlersController : ControllerBase
    {
        private readonly SqlDbContext _context;

        public HandlersController(SqlDbContext context)
        {
            _context = context;
        }

        // GET: api/Handlers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HandlerEntity>>> GetHandlers()
        {
            return await _context.Handlers.ToListAsync();
        }

        // GET: api/Handlers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HandlerEntity>> GetHandlerEntity(int id)
        {
            var handlerEntity = await _context.Handlers.FindAsync(id);

            if (handlerEntity == null)
            {
                return NotFound();
            }

            return handlerEntity;
        }

        // PUT: api/Handlers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHandlerEntity(int id, HandlerEntity handlerEntity)
        {
            if (id != handlerEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(handlerEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HandlerEntityExists(id))
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

        // POST: api/Handlers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HandlerEntity>> PostHandlerEntity(HandlerEntity handlerEntity)
        {
            _context.Handlers.Add(handlerEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHandlerEntity", new { id = handlerEntity.Id }, handlerEntity);
        }

        // DELETE: api/Handlers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHandlerEntity(int id)
        {
            var handlerEntity = await _context.Handlers.FindAsync(id);
            if (handlerEntity == null)
            {
                return NotFound();
            }

            _context.Handlers.Remove(handlerEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HandlerEntityExists(int id)
        {
            return _context.Handlers.Any(e => e.Id == id);
        }
    }
}
