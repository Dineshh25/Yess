using System.Diagnostics.Eventing.Reader;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
using Yess.Models;
using Yess.Services;

namespace Yess.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductsController(IProductService productService )
        {
            _productService = productService;
            //_categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var products = _productService.GetAllProducts();
            return View(products);
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
                _productService.AddProduct(product);
                //-ProductService.Savechanges();
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
            var product = _productService.GetProductById(ProductId);
            //if (product == null)
            //{
            //    return RedirectToAction("Index");
            //}
            //else
            //{
                ViewBag.Categories = _productService.GetAllCategories();
                return View(product);
            //}
        }
            

        
        [HttpPost]
         
        public IActionResult Edit(Product product)
        {
            //var product = context.Products.Find(ProductId);

            //if (product == null || product.ProductId <= 0)
            //{
            //    return RedirectToAction("Index");
            //}
            // Optionally, you can check if the product exists in the database
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _productService.GetAllCategories();
                return View(product);
            }
            //var existingProduct = _productService.GetProductById(product.ProductId); // Assuming you have this service method
            //if (existingProduct == null)
            //{
            //    // If no product found with the given ID, redirect to the Index page
            //    return RedirectToAction("Index");
            //}

            _productService.UpdateProduct(product);
            return RedirectToAction("Index");



        }
        //public IActionResult Delete(int ProductId)
        //{
        //    var product = _productService.GetProductById(ProductId);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(product);
        //}

        [HttpPost]
        public IActionResult Delete(int ProductId)
        {
           
            var product = _productService.GetProductById(ProductId);

            if (product == null)
            {
                return RedirectToAction("Index");
            }
            _productService.DeleteProduct(ProductId);
            return RedirectToAction("Index");
        }
    }
}
