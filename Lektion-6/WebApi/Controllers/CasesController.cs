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
    public class CasesController : ControllerBase
    {
        private readonly SqlDbContext _context;

        public CasesController(SqlDbContext context)
        {
            _context = context;
        }



        // GET: api/Cases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CaseModel>>> GetCases()
        {
            var items = new List<CaseModel>();
            foreach (var item in await _context.Cases.Include(x => x.Status).Include(x => x.Customer).Include(x => x.CaseHandler).ThenInclude(x => x.Handler).ToListAsync())
            {
                if (item.CaseHandler != null)
                    items.Add(new CaseModel(
                        item.Id,
                        item.Description,
                        item.Created,
                        item.Modified,
                        new StatusModel(item.Status.Id, item.Status.Name),
                        new CustomerModel(item.Customer.Id, item.Customer.FirstName, item.Customer.LastName, item.Customer.Email),
                        new HandlerModel(item.CaseHandler.Handler.Id, item.CaseHandler.Handler.FirstName, item.CaseHandler.Handler.LastName, item.CaseHandler.Handler.Email)
                    ));
                else
                    items.Add(new CaseModel(
                        item.Id,
                        item.Description,
                        item.Created,
                        item.Modified,
                        new StatusModel(item.Status.Id, item.Status.Name),
                        new CustomerModel(item.Customer.Id, item.Customer.FirstName, item.Customer.LastName, item.Customer.Email)
                    ));
            }

            return items;
        }





        // GET: api/Cases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CaseModel>> GetCaseEntity(int id)
        {
            var caseEntity = await _context.Cases.Include(x => x.Status).Include(x => x.Customer).Include(x => x.CaseHandler).ThenInclude(x => x.Handler).FirstOrDefaultAsync(x => x.Id == id);

            if (caseEntity == null)
            {
                return NotFound();
            }
         
            if (caseEntity.CaseHandler != null)
                return new CaseModel(
                    caseEntity.Id,
                    caseEntity.Description,
                    caseEntity.Created,
                    caseEntity.Modified,
                    new StatusModel(caseEntity.Status.Id, caseEntity.Status.Name),
                    new CustomerModel(caseEntity.Customer.Id, caseEntity.Customer.FirstName, caseEntity.Customer.LastName, caseEntity.Customer.Email),
                    new HandlerModel(caseEntity.CaseHandler.Handler.Id, caseEntity.CaseHandler.Handler.FirstName, caseEntity.CaseHandler.Handler.LastName, caseEntity.CaseHandler.Handler.Email)
                );
            else
                return new CaseModel(
                    caseEntity.Id,
                    caseEntity.Description,
                    caseEntity.Created,
                    caseEntity.Modified,
                    new StatusModel(caseEntity.Status.Id, caseEntity.Status.Name),
                    new CustomerModel(caseEntity.Customer.Id, caseEntity.Customer.FirstName, caseEntity.Customer.LastName, caseEntity.Customer.Email)
                );
        }

        // PUT: api/Cases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCaseEntity(int id, CaseUpdateModel caseUpdateModel)
        {
            if (id != caseUpdateModel.Id)
            {
                return BadRequest();
            }

            var caseEntity = await _context.Cases.FindAsync(id);
            caseEntity.Description = caseUpdateModel.Description;
            caseEntity.Modified = DateTime.Now;
            caseEntity.StatusId = caseUpdateModel.StatusId;

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
        public async Task<ActionResult<CaseModel>> PostCaseEntity(CaseCreateModel caseCreateModel)
        {
            if (!await _context.Customers.AnyAsync(x => x.Id == caseCreateModel.CustomerId))
                return BadRequest();

            var _caseEntity = new CaseEntity(
                caseCreateModel.Description,
                DateTime.Now,
                DateTime.Now,
                (await _context.Statuses.FirstOrDefaultAsync(x => x.Name == "Ej påbörjad")).Id,
                caseCreateModel.CustomerId
            );

            _context.Cases.Add(_caseEntity);
            await _context.SaveChangesAsync();

            var caseEntity = await _context.Cases.Include(x => x.Status).Include(x => x.Customer).FirstOrDefaultAsync(x => x.Id == _caseEntity.Id);

            return CreatedAtAction("GetCaseEntity", new { id = caseEntity.Id }, new CaseModel(
                    caseEntity.Id,
                    caseEntity.Description,
                    caseEntity.Created,
                    caseEntity.Modified,
                    new StatusModel(caseEntity.Status.Id, caseEntity.Status.Name),
                    new CustomerModel(caseEntity.Customer.Id, caseEntity.Customer.FirstName, caseEntity.Customer.LastName, caseEntity.Customer.Email)
            ));
        }

        private bool CaseEntityExists(int id)
        {
            return _context.Cases.Any(e => e.Id == id);
        }
    }
}
