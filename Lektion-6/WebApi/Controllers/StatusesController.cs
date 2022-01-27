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
    public class StatusesController : ControllerBase
    {
        private readonly SqlDbContext _context;

        public StatusesController(SqlDbContext context)
        {
            _context = context;
        }






        // GET: api/Statuses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusModel>>> GetStatuses()
        {
            var items = new List<StatusModel>();
            foreach (var item in await _context.Statuses.ToListAsync())
                items.Add(new StatusModel(item.Id, item.Name));

            return items;
        }



        // GET: api/Statuses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusModel>> GetStatusEntity(int id)
        {
            var statusEntity = await _context.Statuses.FindAsync(id);

            if (statusEntity == null)
            {
                return NotFound();
            }

            return new StatusModel(statusEntity.Id, statusEntity.Name);
        }


        // PUT: api/Statuses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatusEntity(int id, StatusModel statusModel)
        {
            if (id != statusModel.Id)
            {
                return BadRequest();
            }

            var statusEntity = await _context.Statuses.FindAsync(statusModel.Id);
            statusEntity.Name = statusModel.Name;

            _context.Entry(statusEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusEntityExists(id))
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




        // POST: api/Statuses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StatusModel>> PostStatusEntity(StatusModel statusModel)
        {
            var statusEntity = new StatusEntity(statusModel.Name);

            if(await _context.Statuses.AnyAsync(x => x.Name == statusModel.Name))
                return Conflict();


            _context.Statuses.Add(statusEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStatusEntity", new { id = statusEntity.Id }, new StatusModel(statusEntity.Id, statusEntity.Name));
        }



        // DELETE: api/Statuses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatusEntity(int id)
        {
            var statusEntity = await _context.Statuses.FindAsync(id);
            if (statusEntity == null)
            {
                return NotFound();
            }

            _context.Statuses.Remove(statusEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StatusEntityExists(int id)
        {
            return _context.Statuses.Any(e => e.Id == id);
        }
    }
}
