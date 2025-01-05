using Yess.Models;

namespace Yess.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int categoryId);
        Task<Category> AddCategoryAsync(Category category);
        Task<bool> UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(int CategoryId);

    }
}
