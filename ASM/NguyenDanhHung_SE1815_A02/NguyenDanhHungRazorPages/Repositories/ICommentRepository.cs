using NguyenDanhHungRazorPages.Models;

namespace NguyenDanhHungRazorPages.Repositories
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetCommentsByNewsIdAsync(string newsId);
        Task<Comment> AddCommentAsync(Comment comment);
        Task<Comment> GetCommentByIdAsync(int commentId);
        Task UpdateCommentAsync(Comment comment);
        Task<bool> DeleteCommentAsync(int commentId);
    }
}
