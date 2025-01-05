using System.Diagnostics.Eventing.Reader;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Yess.Models;
using Yess.Services;

namespace Yess.Controllers
{
    
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        //private readonly ICategoryService _categoryService;

        public ProductsController(IProductService productService )
        {
            _productService = productService;
            //_categoryService = categoryService;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            var pagedResult = _productService.GetPagedProducts(pageNumber, pageSize);

            ViewBag.PageNumber = pagedResult.PageNumber;
            ViewBag.TotalPages = pagedResult.TotalPages;

            return View(pagedResult.Items);  // Pass the paginated list to the view
        }

       

        [HttpGet]

        public IActionResult Create()
        {
            ViewBag.Categories = _productService.GetAllCategories();
            return View();
        }


        [HttpPost]
        public IActionResult Create(Product product)
        {
            var categoryExists = _productService.GetCategoryById(product.CategoryId) != null;

            if (!categoryExists)
            {
                ModelState.AddModelError("CategoryId", "The selected category does not exist.");
            }
            if (ModelState.IsValid)
            {
                var category = _productService.GetCategoryById(product.CategoryId);
                if (category != null)
                {
                    product.CategoryName = category.CategoryName;  // Set the CategoryName before saving
                }

                _productService.AddProduct(product);
                return RedirectToAction("Index");

            }
            else
            {
                ViewBag.Categories = _productService.GetAllCategories();
                return View(product);
            }
        }



        [HttpGet]
        public IActionResult Edit(int ProductId) 
        {
            ViewBag.Categories = _productService.GetAllCategories();
            return View();
        }


        [HttpPost]
        public IActionResult Edit(Product product)
        {
            

            if (ModelState.IsValid)
            {
                //var existingProduct = _productService.GetProductById(product.ProductId);
                //existingProduct.ProductName = product.ProductName;
                _productService.UpdateProduct(product);
                return RedirectToAction("Index");
            }
                //ViewBag.Categories = _productService.GetAllCategories();
                return View(product);
             
        }


        [HttpPost]
        public IActionResult Delete(int productId)
        {
           
            var product = _productService.GetProductById(productId);
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            _productService.DeleteProduct(productId);
            return RedirectToAction("Index");
        }
    }
}
