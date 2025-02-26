using NguyenDanhHungMVC.Models;

namespace NguyenDanhHungMVC.Services
{
    public interface ITagService
    {
        List<Tag> GetAllTags();
        List<Tag> GetTagsForArticle(string articleId);
        void AddTagToArticle(string articleId, int tagId);
        void RemoveTagFromArticle(string articleId, int tagId);
        void UpdateTagsForArticle(string articleId, List<int> tagIds);
    }
}
