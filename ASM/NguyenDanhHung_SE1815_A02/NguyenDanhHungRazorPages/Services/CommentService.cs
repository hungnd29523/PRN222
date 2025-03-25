using NguyenDanhHungRazorPages.Models;
using NguyenDanhHungRazorPages.Repositories;

namespace NguyenDanhHungRazorPages.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<List<Comment>> GetCommentsByNewsIdAsync(string newsId)
        {
            return await _commentRepository.GetCommentsByNewsIdAsync(newsId);
        }

        public async Task<Comment> AddCommentAsync(string newsId, short userId, string content)
        {
            var comment = new Comment
            {
                NewsId = newsId,
                UserId = userId,
                Content = content,
                CreatedAt = DateTime.UtcNow
            };

            return await _commentRepository.AddCommentAsync(comment);
        }
        public async Task<Comment> EditCommentAsync(int commentId, string newContent)
        {
            var comment = await _commentRepository.GetCommentByIdAsync(commentId);
            if (comment == null) return null;

            comment.Content = newContent;
            await _commentRepository.UpdateCommentAsync(comment);

            return comment;
        }

        public async Task<bool> DeleteCommentAsync(int commentId)
        {
            return await _commentRepository.DeleteCommentAsync(commentId);
        }


    }
}
