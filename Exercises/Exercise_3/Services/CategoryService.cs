using Exercise_3.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercise_3.Services
{
    public interface ICategoryService
    {
        Task<Category> CreateAsync(string name);
        Task<IEnumerable<Category>> ReadAsync();
    }

    public class CategoryService : ICategoryService
    {
        private readonly SqlDbContext _context;

        public CategoryService(SqlDbContext context)
        {
            _context = context;
        }

        public async Task<Category> CreateAsync(string name)
        {
            var categoryEntity = await _context.Categories.FirstOrDefaultAsync(x => x.Name == name);
            if (categoryEntity == null)
            {
                categoryEntity.Name = name;
                _context.Add(categoryEntity);
                await _context.SaveChangesAsync();
            }
            return new Category(categoryEntity.Id, categoryEntity.Name);
        }

        public async Task<IEnumerable<Category>> ReadAsync()
        {
            var items = new List<Category>();
            foreach (var item in await _context.Categories.ToListAsync())
                items.Add(new Category(item.Id, item.Name));

            return items;
        }
    }
}
