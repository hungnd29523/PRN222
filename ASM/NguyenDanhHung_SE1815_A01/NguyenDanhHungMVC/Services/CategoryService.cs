using NguyenDanhHungMVC.Models;
using NguyenDanhHungMVC.Repositories;

namespace NguyenDanhHungMVC.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _categoryRepository.GetAllCategoriesAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(short categoryId)
        {
            return await _categoryRepository.GetCategoryByIdAsync(categoryId);
        }

        public async Task AddCategoryAsync(Category category)
        {
            await _categoryRepository.AddCategoryAsync(category);
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            await _categoryRepository.UpdateCategoryAsync(category);
        }

        public async Task DeleteCategoryAsync(short categoryId)
        {
            await _categoryRepository.DeleteCategoryAsync(categoryId);
        }
        public async Task<Category?> GetCategoryByParentIdAsync(short id, bool includeParent = false)
        {
            return await _categoryRepository.GetCategoryByParentIdAsync(id, includeParent);
        }


    }
}
