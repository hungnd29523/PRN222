using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NguyenDanhHungRazorPages.Models;
using NguyenDanhHungRazorPages.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NguyenDanhHungRazorPages.Pages.News
{
    public class IndexModel : PageModel
    {
        private readonly INewsService _newsService;

        public IndexModel(INewsService newsService)
        {
            _newsService = newsService;
        }

        public List<NewsArticle> NewsArticles { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string? SearchTerm { get; set; }

        [BindProperty(SupportsGet = true)]
        public bool SortByIdAsc { get; set; } = true;

        public async Task OnGetAsync()
        {
            NewsArticles = await _newsService.GetAllAsync(SearchTerm, SortByIdAsc);
        }

    }
}
