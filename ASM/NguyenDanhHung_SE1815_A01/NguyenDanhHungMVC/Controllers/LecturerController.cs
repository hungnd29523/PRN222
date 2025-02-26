using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NguyenDanhHungMVC.Services;

namespace NguyenDanhHungMVC.Controllers
{
    public class LecturerController : Controller
    {
        private readonly INewsArticleService _newsArticleService;

        private readonly ITagService _tagService;

        public LecturerController(INewsArticleService newsArticleService, ITagService tagService)
        {
            _newsArticleService = newsArticleService;
            _tagService = tagService;
        }

        public async Task<IActionResult> Index()
        {
            var articles = await _newsArticleService.GetNewsActiveAsync();
            return View(articles);
        }


        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsArticle = await _newsArticleService.GetNewsByIdAsync(id);

            if (newsArticle == null)
            {
                return NotFound();
            }
            ViewBag.CreatedByName = await _newsArticleService.GetCreatedByNameAsync(newsArticle.CreatedById) ?? "Unknown";

            ViewBag.UpdatedByName = await _newsArticleService.GetAccountNameByIdAsync(newsArticle.UpdatedById) ?? "Unknown";

            return View(newsArticle);
        }
      

      
    }
}
