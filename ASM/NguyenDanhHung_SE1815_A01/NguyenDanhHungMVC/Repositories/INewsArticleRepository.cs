using NguyenDanhHungMVC.Models;

namespace NguyenDanhHungMVC.Repositories
{
    public interface INewsArticleRepository
    {
        Task<IEnumerable<NewsArticle>> GetAllAsync();
        Task<NewsArticle?> GetByIdAsync(string id);
        Task AddAsync(NewsArticle article);
        Task UpdateAsync(NewsArticle article);
        Task DeleteAsync(string id);
        Task<string?> GetAccountNameByIdAsync(short? accountId);
        Task<string?> GetCreatedByNameAsync(short? createdById);
        Task<bool> IsCategoryUsedAsync(short categoryId);
        Task<IEnumerable<NewsArticle>> GetNewsActiveAsync();
        Task<bool> AddTagsToNewsArticleAsync(string newsArticleId, List<int> tagIds);
        List<Tag> GetTagsForArticle(string newsArticleId);

    }

}
