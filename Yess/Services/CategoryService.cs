using Microsoft.EntityFrameworkCore;
using Yess.Data;
using Yess.Models;
using Yess.Services;

namespace Yess.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;
        //private readonly int CategoryId;


        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public  async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _context.Category.ToListAsync();
        }

        public async Task<Category> AddCategoryAsync(Category category)
        {
            await _context.Category.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        
        public async Task<Category> GetCategoryByIdAsync(int categoryId)
        {
            return await _context.Category.FirstOrDefaultAsync(c => c.CategoryId == categoryId);
        }
        
        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            try
            {
                var existingCategory = await _context.Category.FindAsync(category.CategoryId);

                if (existingCategory == null)
                {
                    return false;
                }

                existingCategory.CategoryName = category.CategoryName;

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
         }


        public async Task DeleteCategoryAsync(int categoryId)
        {
            var category = await _context.Category.FindAsync(categoryId);
            if (category != null)
            {
                _context.Category.Remove(category);
                await _context.SaveChangesAsync();
            }
        }

       
    }
}


