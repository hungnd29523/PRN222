using NguyenDanhHungMVC.Models;

namespace NguyenDanhHungMVC.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category?> GetCategoryByIdAsync(short categoryId);
        Task<Category?> GetCategoryByParentIdAsync(short id, bool includeParent = false);
        Task AddCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(short categoryId);
    }
}
