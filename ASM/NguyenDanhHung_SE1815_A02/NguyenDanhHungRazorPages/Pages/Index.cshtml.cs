using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NguyenDanhHungRazorPages.Pages;
public class IndexModel : PageModel
{
    public int? UserId { get; set; }
    public int? UserRole { get; set; }

    public IActionResult OnGet()
    {
        UserId = HttpContext.Session.GetInt32("UserId");
        UserRole = HttpContext.Session.GetInt32("UserRole");

        if (UserId == null)
        {
            return RedirectToPage("/Account/Login"); // Chưa đăng nhập thì chuyển về Login
        }

        return Page();
    }
}