
using Exercise_2.Models;
using Exercise_2.Models.Entitites;
using Exercise_2.Models.Forms;
using Microsoft.EntityFrameworkCore;

namespace Exercise_2.Services
{
    public interface IProductService
    {
        Task CreateAsync(ProductCreateForm formData);
        Task<IEnumerable<Product>> ReadAsync();
        Task<Product> ReadAsync(int id);
        Task UpdateAsync(int id, ProductUpdateForm formData);
        Task DeleteAsync(int id);
    }


    public class ProductService : IProductService
    {
        private readonly SqlDbContext _context;
        private readonly ICategoryService _categoryService;

        public ProductService(SqlDbContext context, ICategoryService categoryService)
        {
            _context = context;
            _categoryService = categoryService; 
        }

        public async Task CreateAsync(ProductCreateForm formData)
        {
            var category = await _categoryService.CreateAsync(formData.CategoryName);
            
            _context.Products.Add(new ProductEntity(formData.BarCode, formData.Name, formData.Description, formData.Price, category.Id));
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            _context.Remove(await _context.Products.FindAsync(id));
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> ReadAsync()
        {
            var items = new List<Product>();
            foreach (var item in await _context.Products.Include(x => x.Category).ToListAsync())
                items.Add(new Product(item.Id, item.BarCode, item.Name, item.Description, item.Price, item.Category.Name));

            return items;
        }

        public async Task<Product> ReadAsync(int id)
        {
            var item = await _context.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
            return new Product(item.Id, item.BarCode, item.Name, item.Description, item.Price, item.Category.Name);
        }

        public async Task UpdateAsync(int id, ProductUpdateForm formData)
        {
            if(id == formData.Id)
            {
                var category = await _categoryService.CreateAsync(formData.CategoryName);

                var productEntity = await _context.Products.FindAsync(id);
                if(productEntity != null)
                {
                    productEntity.BarCode = formData.BarCode;
                    productEntity.Name = formData.Name;
                    productEntity.Description = formData.Description;
                    productEntity.Price = formData.Price;
                    productEntity.CategoryId = category.Id;

                    _context.Update(productEntity);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
