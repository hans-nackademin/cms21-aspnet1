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
    public class CasesController : ControllerBase
    {
        private readonly SqlDbContext _context;

        public CasesController(SqlDbContext context)
        {
            _context = context;
        }

        // GET: api/Cases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CaseEntity>>> GetCases()
        {
            return await _context.Cases.ToListAsync();
        }

        // GET: api/Cases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CaseEntity>> GetCaseEntity(Guid id)
        {
            var caseEntity = await _context.Cases.FindAsync(id);

            if (caseEntity == null)
            {
                return NotFound();
            }

            return caseEntity;
        }

        // PUT: api/Cases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCaseEntity(Guid id, CaseEntity caseEntity)
        {
            if (id != caseEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(caseEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaseEntityExists(id))
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

        // POST: api/Cases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CaseEntity>> PostCaseEntity(CaseEntity caseEntity)
        {
            _context.Cases.Add(caseEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCaseEntity", new { id = caseEntity.Id }, caseEntity);
        }

        // DELETE: api/Cases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCaseEntity(Guid id)
        {
            var caseEntity = await _context.Cases.FindAsync(id);
            if (caseEntity == null)
            {
                return NotFound();
            }

            _context.Cases.Remove(caseEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CaseEntityExists(Guid id)
        {
            return _context.Cases.Any(e => e.Id == id);
        }
    }
}
