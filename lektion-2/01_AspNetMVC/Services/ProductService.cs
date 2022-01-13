using _01_AspNetMVC.Data;
using _01_AspNetMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace _01_AspNetMVC.Services
{
    public interface IProductService
    {
        Task AddAsync(ProductModel model);
        Task<IEnumerable<ProductModel>> GetAllAsync();
    }

    public class ProductService : IProductService
    {
        private readonly SqlContext _context;

        public ProductService(SqlContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ProductModel model)
        {
            _context.Products.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductModel>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
