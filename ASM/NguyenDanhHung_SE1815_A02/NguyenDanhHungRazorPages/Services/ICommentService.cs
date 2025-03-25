using NguyenDanhHungRazorPages.Models;

namespace NguyenDanhHungRazorPages.Services
{
    public interface ICommentService
    {
        Task<List<Comment>> GetCommentsByNewsIdAsync(string newsId);
        Task<Comment> AddCommentAsync(string newsId, short userId, string content);
        Task<Comment> EditCommentAsync(int commentId, string newContent);
        Task<bool> DeleteCommentAsync(int commentId);
    }

}
