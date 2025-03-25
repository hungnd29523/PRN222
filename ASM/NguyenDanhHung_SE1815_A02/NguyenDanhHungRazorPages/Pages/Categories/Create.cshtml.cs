using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NguyenDanhHungRazorPages.Models;
using NguyenDanhHungRazorPages.Services;

namespace NguyenDanhHungRazorPages.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        public CreateModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [BindProperty]
        public Category Category { get; set; } = new();

        public List<Category> ParentCategories { get; set; } = new();

        public async Task OnGetAsync()
        {
            ParentCategories = await _categoryService.GetAllCategoryAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ParentCategories = await _categoryService.GetAllCategoryAsync();
                return Page();
            }

            await _categoryService.CreateAsync(Category);
            return RedirectToPage("Index");
        }
    }

}
