using Microsoft.EntityFrameworkCore;
using NguyenDanhHungMVC.Models;
using NuGet.Packaging;

namespace NguyenDanhHungMVC.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly FunewsManagementContext _context;

        public TagRepository(FunewsManagementContext context)
        {
            _context = context;
        }

        public NewsArticle GetById(string id)
        {
            return _context.NewsArticles.Include(na => na.Tags).FirstOrDefault(na => na.NewsArticleId == id);
        }

        public List<Tag> GetAllTags()
        {
            return _context.Tags.ToList();
        }

        public List<Tag> GetTagsForArticle(string articleId)
        {
            return _context.NewsArticles
                .Where(na => na.NewsArticleId == articleId)
                .SelectMany(na => na.Tags)
                .ToList();
        }

        public void AddTagToArticle(string articleId, int tagId)
        {
            var article = GetById(articleId);
            var tag = _context.Tags.Find(tagId);
            if (article != null && tag != null && !article.Tags.Contains(tag))
            {
                article.Tags.Add(tag);
                _context.SaveChanges();
            }
        }

        public void RemoveTagFromArticle(string articleId, int tagId)
        {
            var article = GetById(articleId);
            var tag = article?.Tags.FirstOrDefault(t => t.TagId == tagId);
            if (article != null && tag != null)
            {
                article.Tags.Remove(tag);
                _context.SaveChanges();
            }
        }

        public void UpdateTagsForArticle(string articleId, List<int> tagIds)
        {
            var article = _context.NewsArticles
                .Include(a => a.Tags) // Include Tags để tránh lỗi Lazy Loading
                .FirstOrDefault(a => a.NewsArticleId == articleId);

            if (article != null)
            {
                // Xóa tất cả Tag cũ trong bảng trung gian
                var existingTags = article.Tags.ToList();
                foreach (var tag in existingTags)
                {
                    article.Tags.Remove(tag);
                }

                // Thêm các Tag mới vào
                var newTags = _context.Tags.Where(t => tagIds.Contains(t.TagId)).ToList();
                article.Tags.AddRange(newTags);

                _context.SaveChanges();
            }
        }

    }

}
