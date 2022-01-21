using _00_AspNetMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace _00_AspNetMVC.Services
{
    public interface ICategoryService
    {
        Task<ProductCategory> CreateCategoryAsync(string categoryName);
        Task<ProductSubCategory> CreateSubCategoryAsync(string subCategoryName, string categoryName);
    }

    public class CategoryService : ICategoryService
    {
        private readonly SqlContext _context;

        public CategoryService(SqlContext context)
        {
            _context = context;
        }

        public Task<ProductCategory> CreateCategoryAsync(string categoryName)
        {
            throw new NotImplementedException();
        }

        public Task<ProductSubCategory> CreateSubCategoryAsync(string subCategoryName, string categoryName)
        {
            throw new NotImplementedException();
        }
    }
}
