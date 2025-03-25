using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using NguyenDanhHungRazorPages.Services;
using NguyenDanhHungRazorPages.Models;
using Microsoft.AspNetCore.Http;

namespace NguyenDanhHungRazorPages.Pages.News
{
    public class CommentsModel : PageModel
    {
        private readonly ICommentService _commentService;

        public CommentsModel(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [BindProperty(SupportsGet = true)]
        public string NewsId { get; set; }

        public List<Comment> Comments { get; set; }

        public short CurrentUserId { get; set; }
        public bool IsAdmin { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (string.IsNullOrEmpty(NewsId))
            {
                return RedirectToPage("/News/Index");
            }

            Comments = await _commentService.GetCommentsByNewsIdAsync(NewsId);

            // Ép kiểu int về short
            CurrentUserId = (short)(HttpContext.Session.GetInt32("UserId") ?? 0);
            IsAdmin = HttpContext.Session.GetString("UserRole") == "Admin";

            return Page();
        }
        public async Task<IActionResult> OnPostEditCommentAsync(int commentId, string newContent)
        {
            await _commentService.EditCommentAsync(commentId, newContent);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteCommentAsync(int commentId)
        {
            await _commentService.DeleteCommentAsync(commentId);
            return RedirectToPage();
        }

    }
}
