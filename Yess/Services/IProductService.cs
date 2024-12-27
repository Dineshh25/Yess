using Yess.Models;

namespace Yess.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();

        //IEnumerable<Product> GetAllProducts(int page, int pageSize);
        Product GetProductById(int productid);
        void AddProduct(Product product);

        //List<Product> GetAllProducts();

        //List<Category> GetAllCategories();
        void UpdateProduct(Product product);
        IEnumerable<Category> GetAllCategories();
        void DeleteProduct(int productId);
        
        Category GetCategoryById(int categoryId);
    }
}
