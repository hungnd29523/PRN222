using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using NguyenDanhHungRazorPages.Services;
using NguyenDanhHungRazorPages.Models;

public class CommentHub : Hub
{
    private readonly ICommentService _commentService;

    public CommentHub(ICommentService commentService)
    {
        _commentService = commentService;
    }

    public async Task SendComment(string newsId, string userId, string content)
    {
        if (string.IsNullOrWhiteSpace(content)) return;

        var comment = await _commentService.AddCommentAsync(newsId, short.Parse(userId), content);

        await Clients.All.SendAsync("ReceiveComment", new
        {
            comment.Id,
            comment.NewsId,
            comment.User.AccountName,
            comment.Content,
            CreatedAt = comment.CreatedAt?.ToString("yyyy-MM-dd HH:mm")
        });
    }
   public async Task EditComment(int commentId, string newContent)
{
    Console.WriteLine($"EditComment called: commentId={commentId}, newContent={newContent}");

    if (string.IsNullOrWhiteSpace(newContent)) return;

    var updatedComment = await _commentService.EditCommentAsync(commentId, newContent);
    if (updatedComment != null)
    {
        Console.WriteLine($"EditComment Success: {updatedComment.Id}");
        await Clients.All.SendAsync("UpdateComment", new
        {
            id = updatedComment.Id,
            content = updatedComment.Content,
            createdAt = updatedComment.CreatedAt?.ToString("yyyy-MM-dd HH:mm")
        });
    }
    else
    {
        Console.WriteLine("EditComment Failed");
    }
}


    public async Task DeleteComment(int commentId)
    {
        var isDeleted = await _commentService.DeleteCommentAsync(commentId);
        if (isDeleted)
        {
            await Clients.All.SendAsync("RemoveComment", commentId);
        }
    }


}
