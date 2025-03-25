using NguyenDanhHungRazorPages.Models;
using Microsoft.EntityFrameworkCore;

namespace NguyenDanhHungRazorPages.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly FunewsManagementContext _context;

        public CommentRepository(FunewsManagementContext context)
        {
            _context = context;
        }

        public async Task<List<Comment>> GetCommentsByNewsIdAsync(string newsId)
        {
            return await _context.Comments
                .Include(c => c.User)
                .Where(c => c.NewsId == newsId)
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();
        }

        public async Task<Comment> AddCommentAsync(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
            return await _context.Comments.Include(c => c.User)
                                          .FirstOrDefaultAsync(c => c.Id == comment.Id);
        }

        public async Task<Comment> GetCommentByIdAsync(int commentId)
        {
            return await _context.Comments.FindAsync(commentId);
        }

        public async Task UpdateCommentAsync(Comment comment)
        {
            _context.Comments.Update(comment);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteCommentAsync(int commentId)
        {
            var comment = await _context.Comments.FindAsync(commentId);
            if (comment == null) return false;

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return true;
        }


    }

}
