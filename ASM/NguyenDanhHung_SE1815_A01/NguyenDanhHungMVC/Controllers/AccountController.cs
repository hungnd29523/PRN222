using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NguyenDanhHungMVC.Models;
using NguyenDanhHungMVC.Services;
namespace NguyenDanhHungMVC.Controllers
{


    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IConfiguration _configuration;
        public AccountController(IAccountService accountService, IConfiguration configuration)
        {
            _accountService = accountService;
            _configuration = configuration; 
        }

        public async Task<IActionResult> Index()
        {
            var accounts = await _accountService.GetAllSystemAccountAsync();
            return View(accounts);
        }

        public async Task<IActionResult> Login(string email, string password)
        {
            var adminEmail = _configuration["AdminAccount:Email"];
            var adminPassword = _configuration["AdminAccount:Password"];
            var adminAccountId = int.Parse(_configuration["AdminAccount:AccountId"]);
            var adminAccountName = _configuration["AdminAccount:AccountName"];
            var adminAccountRole = int.Parse(_configuration["AdminAccount:AccountRole"]);

            if (email == adminEmail && password == adminPassword)
            {
                HttpContext.Session.SetInt32("AccountId", adminAccountId);
                HttpContext.Session.SetString("AccountName", adminAccountName);
                HttpContext.Session.SetString("AccountEmail", adminEmail);
                HttpContext.Session.SetInt32("AccountRole", adminAccountRole);

                return RedirectToAction("Index", "Account"); 
            }

            var user = await _accountService.ValidateLoginAsync(email, password);
            if (user != null)
            {
                HttpContext.Session.SetInt32("AccountId", user.AccountId);
                HttpContext.Session.SetString("AccountName", user.AccountName ?? "Unknown");
                HttpContext.Session.SetString("AccountEmail", user.AccountEmail ?? "Unknown");
                HttpContext.Session.SetInt32("AccountRole", user.AccountRole ?? 0);

                
                if (user.AccountRole == 1)
                {
                    return RedirectToAction("Index", "NewsArticle");
                }
                else if (user.AccountRole == 2)
                {
                    return RedirectToAction("Index", "Lecturer");
                }
                else
                {
                    return RedirectToAction("Index", "Account");
                }

            }

            ModelState.AddModelError("", "Invalid login attempt.");
            return View();
        }


        public async Task<IActionResult> ViewProfile()
        {
            int? accountIdInt = HttpContext.Session.GetInt32("AccountId");

            if (!accountIdInt.HasValue)
            {
                return RedirectToAction("Login");
            }

            short accountId = (short)accountIdInt.Value;

            var account = await _accountService.GetSystemAccountByIdAsync(accountId);

            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            int? accountId = HttpContext.Session.GetInt32("AccountId");
            if (accountId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var account = await _accountService.GetSystemAccountByIdAsync((short)accountId);
            if (account == null)
            {
                return NotFound();
            }

            var viewModel = new EditProfileViewModel
            {
                AccountName = account.AccountName ?? string.Empty
            };

            return View(viewModel);
        }





        [HttpPost]
        public async Task<IActionResult> EditProfile(string accountName, string newPassword)
        {
            short? accountId = (short?)HttpContext.Session.GetInt32("AccountId");
            if (accountId == null)
            {
                return RedirectToAction("Login", "Account"); 
            }

            bool result = await _accountService.EditProfileAsync(accountId.Value, accountName, newPassword);
            if (result)
            {
                HttpContext.Session.SetString("AccountName", accountName);
                TempData["SuccessMessage"] = "Profile updated successfully.";
                return RedirectToAction("ViewProfile", "Account"); 
            }

            ModelState.AddModelError("", "Failed to update profile.");
            return View();
        }




        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); 
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> Details(short id)
        {
            var account = await _accountService.GetSystemAccountByIdAsync(id);

            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        public async Task<IActionResult> Create()
        {
            var accounts = await _accountService.GetAllSystemAccountAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SystemAccount account)
        {
            if (!ModelState.IsValid)
            {
                var accounts = await _accountService.GetAllSystemAccountAsync();
                return View(account);
            }

            await _accountService.AddSystemAccountAsync(account);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(short id)
        {
            if (id == 0)
                return NotFound();

            var account = await _accountService.GetSystemAccountByIdAsync(id);
            if (account == null)
                return NotFound();


            return View(account);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SystemAccount account)
        {
            if (!ModelState.IsValid)
            {
                var accounts = await _accountService.GetAllSystemAccountAsync();
                return View(account);
            }

            await _accountService.UpdateSystemAccountAsync(account);
            return RedirectToAction(nameof(Index));
        }




        public async Task<IActionResult> Delete(short id)
        {
            var account = await _accountService.GetSystemAccountByIdAsync(id);

            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            var account = await _accountService.GetSystemAccountByIdAsync(id);

            if (account != null)
            {
                await _accountService.DeleteSystemAccountAsync(id); 
            }

            return RedirectToAction("Index");
        }



    }
}

