using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NguyenDanhHungMVC.Models;
using NguyenDanhHungMVC.Services;

namespace NguyenDanhHungMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly INewsArticleService _newsArticleService;
        public CategoryController(ICategoryService categoryService, INewsArticleService newsArticleService)
        {
            _categoryService = categoryService;
            _newsArticleService = newsArticleService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();

            return View(categories);
        }

        public async Task<IActionResult> Details(short id)
        {
            var category = await _categoryService.GetCategoryByParentIdAsync(id, includeParent: true);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            ViewBag.ParentCategoryId = new SelectList(categories, "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                var categories = await _categoryService.GetAllCategoriesAsync();
                ViewBag.ParentCategoryId = new SelectList(categories, "CategoryId", "CategoryName");
                return View(category);
            }

            await _categoryService.AddCategoryAsync(category);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(short id)
        {
            if (id == 0)
                return NotFound();

            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
                return NotFound();

            var categories = (await _categoryService.GetAllCategoriesAsync())
                             .Where(c => c.CategoryId != id)
                             .ToList();

            ViewBag.ParentCategoryId = new SelectList(categories, "CategoryId", "CategoryName", category.ParentCategoryId);
            return View(category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category category)
        {
            if (!ModelState.IsValid)
            {
                var categories = await _categoryService.GetAllCategoriesAsync();
                ViewBag.ParentCategoryId = new SelectList(categories, "CategoryId", "CategoryName", category.ParentCategoryId);
                return View(category);
            }

            await _categoryService.UpdateCategoryAsync(category);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(short id)
        {
            var category = await _categoryService.GetCategoryByParentIdAsync(id, includeParent: true);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }



        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            bool isCategoryUsed = await _newsArticleService.IsCategoryUsedAsync(id);

            if (isCategoryUsed)
            {
                TempData["ErrorMessage"] = "Cannot delete this category because it is associated with one or more news articles.";
                return RedirectToAction("Delete");
            }

            await _categoryService.DeleteCategoryAsync(id);
            TempData["SuccessMessage"] = "Category deleted successfully.";

            return RedirectToAction("Index");
        }



    }
}
