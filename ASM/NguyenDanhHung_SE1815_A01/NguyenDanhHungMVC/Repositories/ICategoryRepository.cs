using NguyenDanhHungMVC.Models;

namespace NguyenDanhHungMVC.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category?> GetCategoryByIdAsync(short categoryId);
        Task AddCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(short categoryId);
        Task<Category?> GetCategoryByParentIdAsync(short id, bool includeParent = false);
    }
}
