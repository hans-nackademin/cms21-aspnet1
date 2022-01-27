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
    public class HandlersController : ControllerBase
    {
        private readonly SqlDbContext _context;

        public HandlersController(SqlDbContext context)
        {
            _context = context;
        }

        // GET: api/Handlers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HandlerModel>>> GetHandlers()
        {
            var items = new List<HandlerModel>();
            foreach(var item in await _context.Handlers.ToListAsync())
                items.Add(new HandlerModel(item.Id, item.FirstName, item.LastName, item.Email));
            
            return items;
        }

        // GET: api/Handlers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HandlerModel>> GetHandlerEntity(int id)
        {
            var handlerEntity = await _context.Handlers.FindAsync(id);

            if (handlerEntity == null)
            {
                return NotFound();
            }

            return new HandlerModel(handlerEntity.Id, handlerEntity.FirstName, handlerEntity.LastName, handlerEntity.Email);
        }

        // PUT: api/Handlers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHandlerEntity(int id, HandlerModel handlerModel)
        {
            if (id != handlerModel.Id)
            {
                return BadRequest();
            }

            var handlerEntity = await _context.Handlers.FindAsync(handlerModel.Id);
            handlerEntity.FirstName = handlerModel.FirstName;
            handlerEntity.LastName = handlerModel.LastName;
            handlerEntity.Email = handlerModel.Email;


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
        public async Task<ActionResult<HandlerModel>> PostHandlerEntity(HandlerModel handlerModel)
        {
            if (await _context.Handlers.AnyAsync(x => x.Email == handlerModel.Email))
                return Conflict();

            var handlerEntity = new HandlerEntity(handlerModel.FirstName, handlerModel.LastName, handlerModel.Email);

            _context.Handlers.Add(handlerEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHandlerEntity", new { id = handlerEntity.Id }, new HandlerModel(handlerEntity.Id, handlerEntity.FirstName, handlerEntity.LastName, handlerEntity.Email));
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
