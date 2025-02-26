using NguyenDanhHungMVC.Models;

namespace NguyenDanhHungMVC.Repositories
{
    public interface ITagRepository
    {
        NewsArticle GetById(string id);
        List<Tag> GetAllTags();
        List<Tag> GetTagsForArticle(string articleId);
        void AddTagToArticle(string articleId, int tagId);
        void RemoveTagFromArticle(string articleId, int tagId);
        void UpdateTagsForArticle(string articleId, List<int> tagIds);
    }
}
