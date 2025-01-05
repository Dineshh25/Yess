using Yess.Models;

namespace Yess.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();

        
        Product GetProductById(int productId);

        void AddProduct(Product product);

        PagedResult<Product> GetPagedProducts(int pageNumber, int pageSize);
       
        void UpdateProduct(Product product);

        IEnumerable<Category> GetAllCategories();

        void DeleteProduct(int productId);
        
        Category GetCategoryById(int categoryId);
    }
}
