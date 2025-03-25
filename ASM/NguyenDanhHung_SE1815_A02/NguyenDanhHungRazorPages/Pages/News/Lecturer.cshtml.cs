using Microsoft.AspNetCore.Mvc.RazorPages;
using NguyenDanhHungRazorPages.Models;
using NguyenDanhHungRazorPages.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NguyenDanhHungRazorPages.Pages.News
{
    public class Lecturer : PageModel
    {
        private readonly INewsService _newsService;

        public Lecturer(INewsService newsService)
        {
            _newsService = newsService;
        }

        public List<NewsArticle> NewsArticles { get; set; } = new();

        public async Task OnGetAsync()
        {
            NewsArticles = await _newsService.GetAllActiveAsync();
        }
    }
}
