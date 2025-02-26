using NguyenDanhHungMVC.Models;

namespace NguyenDanhHungMVC.Services
{
    public interface INewsArticleService
    {
        Task<IEnumerable<NewsArticle>> GetAllNewsAsync();
        Task<NewsArticle?> GetNewsByIdAsync(string id);
        Task AddNewsAsync(NewsArticle article);
        Task DeleteNewsAsync(string id);
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<string?> GetAccountNameByIdAsync(short? accountId);
        Task<string?> GetCreatedByNameAsync(short? createdById);
        Task UpdateNewsAsync(NewsArticle article);
        Task<bool> IsCategoryUsedAsync(short categoryId);
        Task<IEnumerable<NewsArticle>> GetNewsActiveAsync();
        Task<bool> AddTagsToNewsArticleAsync(string newsArticleId, List<int> tagIds);
        List<Tag> GetTagsForArticle(string newsArticleId);

    }

}
