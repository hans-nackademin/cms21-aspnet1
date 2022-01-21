using _00_AspNetMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace _00_AspNetMVC.Services
{
    public interface IProductService
    {
        Task CreateAsync(Product product);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<IEnumerable<Product>> GetAllBySubCategoryAsync(string subcategory);

    }

    public class ProductService : IProductService
    {
        private readonly SqlContext _context;

        public ProductService(SqlContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Product product)
        {
            var _product = await _context.Products.FirstOrDefaultAsync(x => x.Name == product.Name);
            if (_product == null)
            {
                _product.Name = product.Name;
                _product.Description = product.Description;
                _product.Price = product.Price;
                
                
                _product.SubCategoryId = 1;
                _context.Add(_product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var products = new List<Product>();
            foreach (var item in await _context.Products.Include(x => x.SubCategory).ThenInclude(x => x.Products).ToListAsync())
                products.Add(new Product
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    SubCategory = item.SubCategory.Name,
                    Category = item.SubCategory.Category.Name
                });

            return products;
        }

        public async Task<IEnumerable<Product>> GetAllBySubCategoryAsync(string subcategory)
        {
            var products = new List<Product>();
            foreach (var item in await _context.Products.Include(x => x.SubCategory).ThenInclude(x => x.Category).Where(x => x.SubCategory.Name == subcategory).ToListAsync())
                products.Add(new Product
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    SubCategory = item.SubCategory.Name,
                    Category = item.SubCategory.Category.Name
                });

            return products;
        }
    }
}
