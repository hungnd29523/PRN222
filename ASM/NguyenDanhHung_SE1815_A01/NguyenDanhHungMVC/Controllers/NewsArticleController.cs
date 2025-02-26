using System;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using NguyenDanhHungMVC.Models;
using NguyenDanhHungMVC.Services;

namespace NguyenDanhHungMVC.Controllers
{
    public class NewsArticleController : Controller
    {
        private readonly INewsArticleService _newsArticleService;
        private readonly ITagService _tagService;
        public NewsArticleController(INewsArticleService newsArticleService, ITagService tagService)
        {
            _newsArticleService = newsArticleService;
            _tagService = tagService;
        }

        public async Task<IActionResult> Index()
        {
            var articles = await _newsArticleService.GetAllNewsAsync();

            return View(articles);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
                return NotFound();

            var article = await _newsArticleService.GetNewsByIdAsync(id);
            if (article == null)
                return NotFound();

            var categories = await _newsArticleService.GetCategoriesAsync();
            ViewBag.CategoryId = new SelectList(categories, "CategoryId", "CategoryName", article.CategoryId);

            return View(article);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(NewsArticle article)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CategoryId = new SelectList(await _newsArticleService.GetCategoriesAsync(), "CategoryId", "CategoryName", article.CategoryId);
                return View(article);
            }
            var accountId = HttpContext.Session.GetInt32("AccountId");

            if (accountId.HasValue)
            {
                article.UpdatedById = (short)accountId.Value;
                article.ModifiedDate = DateTime.Now;
            }
            await _newsArticleService.UpdateNewsAsync(article);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Create()
        {
            var categories = await _newsArticleService.GetCategoriesAsync();
            ViewBag.CategoryId = new SelectList(categories, "CategoryId", "CategoryName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewsArticle newsArticle)
        {
            if (ModelState.IsValid)
            {
                var accountId = HttpContext.Session.GetInt32("AccountId");
                if (accountId == null)
                {
                    return RedirectToAction("Login", "Account");
                }

                newsArticle.CreatedById = (short)accountId;
               newsArticle.UpdatedById = (short)accountId;
                newsArticle.CreatedDate ??= DateTime.Now;
                newsArticle.ModifiedDate ??= DateTime.Now;


                await _newsArticleService.AddNewsAsync(newsArticle);
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(await _newsArticleService.GetCategoriesAsync(), "CategoryId", "CategoryName");
            return View(newsArticle);
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



        public async Task<IActionResult> Delete(string id)
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

            return View(newsArticle);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _newsArticleService.DeleteNewsAsync(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult GetTags(string id)
        {
            var articleTags = _tagService.GetTagsForArticle(id).Select(t => t.TagId).ToList();
            var allTags = _tagService.GetAllTags().Select(t => new { t.TagId, t.TagName }).ToList();

            return Json(new { articleTags, allTags });
        }

        [HttpPost]
        public IActionResult AddTag(string newsArticleId, int tagId)
        {
            _tagService.AddTagToArticle(newsArticleId, tagId);
            return Ok();
        }

        [HttpPost]
        public IActionResult RemoveTag(string newsArticleId, int tagId)
        {
            _tagService.RemoveTagFromArticle(newsArticleId, tagId);
            return Ok();
        }
        [HttpPost]
        public IActionResult UpdateTags([FromBody] UpdateTagsRequest request)
        {
            _tagService.UpdateTagsForArticle(request.NewsArticleId, request.TagIds);
            return Ok();
        }
    }

    public class UpdateTagsRequest
    {
        public string NewsArticleId { get; set; }
        public List<int> TagIds { get; set; }
    }

}

