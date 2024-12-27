using Yess.Models;

namespace Yess.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int CategoryId);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int CategoryId);
        Task CreateCategoryAsync(Category category);
    }
}
