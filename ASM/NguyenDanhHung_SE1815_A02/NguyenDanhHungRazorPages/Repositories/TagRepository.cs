using Microsoft.EntityFrameworkCore;
using NguyenDanhHungRazorPages.Models;
using NuGet.Packaging;

namespace NguyenDanhHungRazorPages.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly FunewsManagementContext _context;

        public TagRepository(FunewsManagementContext context)
        {
            _context = context;
        }


        public async Task<List<Tag>> GetTagsAsync()
        {
            return await _context.Tags.ToListAsync();
        }

        

        public async Task<List<Tag>> GetAllTagsAsync()
        {
            return await _context.Tags.ToListAsync();
        }

        public async Task<List<Tag>> GetTagsByIdsAsync(List<int> tagIds)
        {
            return await _context.Tags.Where(t => tagIds.Contains(t.TagId)).ToListAsync();
        }

       


      
        

       

    }



}


