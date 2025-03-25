using NguyenDanhHungRazorPages.Models;
using Microsoft.EntityFrameworkCore;

namespace NguyenDanhHungRazorPages.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly FunewsManagementContext _context;

        public CategoryRepository(FunewsManagementContext context)
        {  
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }
        public async Task<List<Category>> GetAllCategoryAsync(string? search = null, bool sortByIdAsc = true)
        {
            var query = _context.Categories
                .Include(c => c.ParentCategory)
                .AsQueryable();

            // Lọc theo CategoryName nếu có từ khóa tìm kiếm
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(c => c.CategoryName.Contains(search));
            }

            // Sắp xếp theo ID
            query = sortByIdAsc ? query.OrderBy(c => c.CategoryId) : query.OrderByDescending(c => c.CategoryId);

            return await query.ToListAsync();
        }
        public async Task<List<Category>> GetAllCategoryAsync()
        {
            return await _context.Categories
                .Include(c => c.ParentCategory)
                .ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(short id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task CreateAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(short id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }

    }


}
