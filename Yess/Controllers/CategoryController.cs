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

        public IActionResult Index()
        {
            var categories = _categoryService.GetAllCategories();
            return View(categories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = _categoryService.GetAllCategories();
            return View();
        }

        //[HttpPost]
        //public IActionResult Create(Category category)
        //{
        //    var categoryExists = _categoryService.GetCategoryById(category.CategoryId) != null;
        //    if (!categoryExists)
        //    {
        //        ModelState.AddModelError("CategoryId", "The selected category does not exist.");
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        _categoryService.AddCategory(category);

        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.Categories = _categoryService.GetAllCategories();
        //    return View(category);
        //}
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.CreateCategoryAsync(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public IActionResult Edit(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.UpdateCategory(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public IActionResult Delete(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _categoryService.DeleteCategory(id);
            return RedirectToAction("Index");
        }
    }
}
