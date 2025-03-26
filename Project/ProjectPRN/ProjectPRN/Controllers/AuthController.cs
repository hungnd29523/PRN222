using Microsoft.AspNetCore.Mvc;
using ProjectPRN.Models;
using ProjectPRN.Service;

namespace ProjectPRN.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        // Hiển thị trang đăng ký
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // Xử lý đăng ký
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!_userService.RegisterUser(model))
            {
                ViewBag.Message = "Email đã được sử dụng.";
                return View(model);
            }

            return RedirectToAction("Login");
        }

        // Hiển thị trang đăng nhập
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Xử lý đăng nhập
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _userService.AuthenticateUser(email, password);
            if (user == null)
            {
                ViewBag.Message = "Sai email hoặc mật khẩu.";
                return View();
            }

            HttpContext.Session.SetString("UserId", user.Id.ToString());
            HttpContext.Session.SetString("UserName", user.UserName);
            return RedirectToAction("Index", "Home");
        }

        // Đăng xuất
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }

}
