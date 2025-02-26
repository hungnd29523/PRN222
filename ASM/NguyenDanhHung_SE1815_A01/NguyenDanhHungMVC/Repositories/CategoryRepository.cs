using Microsoft.EntityFrameworkCore;
using NguyenDanhHungMVC.Models;

namespace NguyenDanhHungMVC.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly FunewsManagementContext _context;

        public CategoryRepository(FunewsManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(short categoryId)
        {
            return await _context.Categories.FindAsync(categoryId);
        }

        public async Task AddCategoryAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(short categoryId)
        {
            var category = await _context.Categories.FindAsync(categoryId);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<Category?> GetCategoryByParentIdAsync(short id, bool includeParent = false)
        {
            var query = _context.Categories.AsQueryable();

            if (includeParent)
            {
                query = query.Include(c => c.ParentCategory);
            }

            return await query.FirstOrDefaultAsync(c => c.CategoryId == id);
        }

    }

}

