using Microsoft.AspNetCore.Mvc;
using Yess.Data;
using Yess.Models;
using Yess.Services;

namespace Yess.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            //ViewBag.Categories = _categoryService.GetAllCategories();
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.AddCategoryAsync(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int categoryId)
        {
            var category= await _categoryService.GetCategoryByIdAsync(categoryId);
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit( Category category)
        {
        
            if (ModelState.IsValid)
            {
                bool isUpdated = await _categoryService.UpdateCategoryAsync(category);
                Console.WriteLine($"Update Operation Result: {isUpdated}");

                if (isUpdated)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("", "Unable to update category.");
            }

            //await _categoryService.UpdateCategoryAsync(category);
            //return RedirectToAction(nameof(Index));
        //}

            return View(category);
        }
        

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int CategoryId)
        {
            var category = await _categoryService.GetCategoryByIdAsync(CategoryId);
            if (category == null)
            {
                // Redirect to Index or show an error if the category doesn't exist
                return RedirectToAction(nameof(Index));
            }
            await _categoryService.DeleteCategoryAsync(CategoryId);
            return RedirectToAction(nameof(Index));
        }
    }
}
