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
    public class CaseStatusesController : ControllerBase
    {
        private readonly SqlDbContext _context;

        public CaseStatusesController(SqlDbContext context)
        {
            _context = context;
        }

        // GET: api/CaseStatuses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CaseStatusEntity>>> GetCaseStatuses()
        {
            return await _context.CaseStatuses.ToListAsync();
        }

        // GET: api/CaseStatuses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CaseStatusEntity>> GetCaseStatusEntity(int id)
        {
            var caseStatusEntity = await _context.CaseStatuses.FindAsync(id);

            if (caseStatusEntity == null)
            {
                return NotFound();
            }

            return caseStatusEntity;
        }

        // PUT: api/CaseStatuses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCaseStatusEntity(int id, CaseStatusEntity caseStatusEntity)
        {
            if (id != caseStatusEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(caseStatusEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaseStatusEntityExists(id))
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

        // POST: api/CaseStatuses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CaseStatusEntity>> PostCaseStatusEntity(CaseStatusEntity caseStatusEntity)
        {
            _context.CaseStatuses.Add(caseStatusEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCaseStatusEntity", new { id = caseStatusEntity.Id }, caseStatusEntity);
        }

        // DELETE: api/CaseStatuses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCaseStatusEntity(int id)
        {
            var caseStatusEntity = await _context.CaseStatuses.FindAsync(id);
            if (caseStatusEntity == null)
            {
                return NotFound();
            }

            _context.CaseStatuses.Remove(caseStatusEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CaseStatusEntityExists(int id)
        {
            return _context.CaseStatuses.Any(e => e.Id == id);
        }
    }
}
