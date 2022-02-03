using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _02_WebApi_AuthKey.Models;
using _02_WebApi_AuthKey.Models.Entitites;
using _02_WebApi_AuthKey.Filters;

namespace _02_WebApi_AuthKey.Controllers
{
    [ApiKeyAuth]
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProductsController : ControllerBase
    {
        private readonly SqlDbContext _context;

        public ProductsController(SqlDbContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetProducts()
        {
            var items = new List<ProductModel>();

            foreach (var i in await _context.Products.ToListAsync())
                items.Add(new ProductModel(i.Id, i.Name, i.Description, i.Price));

            return items;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ProductModel>> GetProduct(int id)
        {
            var productEntity = await _context.Products.FindAsync(id);

            if (productEntity == null)
                return NotFound();

            return new ProductModel(productEntity.Id, productEntity.Name, productEntity.Description, productEntity.Price);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, ProductModel model)
        {
            if (id != model.Id)
                return BadRequest();

            var productEntity = await _context.Products.FindAsync(id);
            productEntity.Name = model.Name;
            productEntity.Description = model.Description;
            productEntity.Price = model.Price;
            
            _context.Entry(productEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductEntityExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<ProductModel>> PostProduct(CreateProductModel model)
        {
            var productEntity = new ProductEntity(model.Name, model.Description, model.Price);
            _context.Products.Add(productEntity);
            await _context.SaveChangesAsync();

            return new ProductModel(productEntity.Id, productEntity.Name, productEntity.Description, productEntity.Price);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductEntity(int id)
        {
            var productEntity = await _context.Products.FindAsync(id);
            if (productEntity == null)
                return NotFound();

            _context.Products.Remove(productEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductEntityExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
