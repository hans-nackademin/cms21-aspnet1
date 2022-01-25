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
    public class CaseHandlersController : ControllerBase
    {
        private readonly SqlDbContext _context;

        public CaseHandlersController(SqlDbContext context)
        {
            _context = context;
        }

        // GET: api/CaseHandlers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CaseHandlerEntity>>> GetCaseHandlers()
        {
            return await _context.CaseHandlers.ToListAsync();
        }

        // GET: api/CaseHandlers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CaseHandlerEntity>> GetCaseHandlerEntity(Guid id)
        {
            var caseHandlerEntity = await _context.CaseHandlers.FindAsync(id);

            if (caseHandlerEntity == null)
            {
                return NotFound();
            }

            return caseHandlerEntity;
        }

        // PUT: api/CaseHandlers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCaseHandlerEntity(Guid id, CaseHandlerEntity caseHandlerEntity)
        {
            if (id != caseHandlerEntity.CaseId)
            {
                return BadRequest();
            }

            _context.Entry(caseHandlerEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaseHandlerEntityExists(id))
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

        // POST: api/CaseHandlers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CaseHandlerEntity>> PostCaseHandlerEntity(CaseHandlerEntity caseHandlerEntity)
        {
            _context.CaseHandlers.Add(caseHandlerEntity);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CaseHandlerEntityExists(caseHandlerEntity.CaseId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCaseHandlerEntity", new { id = caseHandlerEntity.CaseId }, caseHandlerEntity);
        }

        // DELETE: api/CaseHandlers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCaseHandlerEntity(Guid id)
        {
            var caseHandlerEntity = await _context.CaseHandlers.FindAsync(id);
            if (caseHandlerEntity == null)
            {
                return NotFound();
            }

            _context.CaseHandlers.Remove(caseHandlerEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CaseHandlerEntityExists(Guid id)
        {
            return _context.CaseHandlers.Any(e => e.CaseId == id);
        }
    }
}
