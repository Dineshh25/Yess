using Yess.Data;
using Yess.Models;

namespace Yess.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;


        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Category.ToList();
        }

        public Category GetCategoryById(int ProductId)
        {
            return _context.Category.FirstOrDefault(c => c.CategoryId == ProductId);
        }

        //public void AddCategory(Category category)
        //{
        //    _context.Category.Add(category);
        //    _context.SaveChanges();
        //}

        public async Task CreateCategoryAsync(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }

            _context.Category.Add(category);
            await _context.SaveChangesAsync();
        }


        public void UpdateCategory(Category category)
        {
            _context.Category.Update(category);
            _context.SaveChanges();
        }

        public void DeleteCategory(int CategoryId)
        {
            var category = _context.Category.FirstOrDefault(c => c.CategoryId == CategoryId);
            if (category != null)
            {
                _context.Category.Remove(category);
                _context.SaveChanges();
            }
        }

        public void AddCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}


