using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;
using NguyenDanhHungMVC.Models;
using System;

namespace NguyenDanhHungMVC.Repositories
{
    public class NewsArticleRepository : INewsArticleRepository
    {
        private readonly FunewsManagementContext _context;

        public NewsArticleRepository(FunewsManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NewsArticle>> GetAllAsync()
        {
            return await _context.NewsArticles
                 .Include(a => a.Tags)
                .Include(n => n.Category) 
                .Include(n => n.CreatedBy) 
                .ToListAsync();
        }
        public async Task<IEnumerable<NewsArticle>> GetNewsActiveAsync()
        {
            return await _context.NewsArticles
                .Where(n => n.NewsStatus == true)
                 .Include(a => a.Tags)
                .ToListAsync();
        }





        public async Task<NewsArticle?> GetByIdAsync(string id)
        {
            return await _context.NewsArticles
         .Include(x => x.Category) 
         .FirstOrDefaultAsync(x => x.NewsArticleId == id);
        }

        public async Task AddAsync(NewsArticle article)
        {
            await _context.NewsArticles.AddAsync(article);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(string id)
        {
            var article = await _context.NewsArticles.FindAsync(id);
            if (article != null)
            {
                _context.NewsArticles.Remove(article);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<string?> GetAccountNameByIdAsync(short? accountId)
        {
            if (!accountId.HasValue) return null;

            return await _context.SystemAccounts
                .Where(a => a.AccountId == accountId.Value)
                .Select(a => a.AccountName)
                .FirstOrDefaultAsync();
        }
        public async Task<string?> GetCreatedByNameAsync(short? createdById)
        {
            if (!createdById.HasValue) return null;

            return await _context.SystemAccounts
                .Where(a => a.AccountId == createdById.Value)
                .Select(a => a.AccountName)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(NewsArticle article)
        {
            var existingArticle = await _context.NewsArticles.FindAsync(article.NewsArticleId);

            if (existingArticle != null)
            {
                existingArticle.NewsTitle = article.NewsTitle;
                existingArticle.Headline = article.Headline;
                existingArticle.NewsContent = article.NewsContent;
                existingArticle.NewsSource = article.NewsSource;
                existingArticle.CategoryId = article.CategoryId;
                existingArticle.NewsStatus = article.NewsStatus;
                existingArticle.UpdatedById = article.UpdatedById;
                existingArticle.ModifiedDate = article.ModifiedDate;


                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> IsCategoryUsedAsync(short categoryId)
        {
            bool isUsedInNewsArticles = await _context.NewsArticles
                .AnyAsync(n => n.CategoryId == categoryId);

            bool isUsedAsParent = await _context.Categories
                .AnyAsync(c => c.ParentCategoryId == categoryId);

            return isUsedInNewsArticles || isUsedAsParent;
        }

        public async Task<bool> AddTagsToNewsArticleAsync(string newsArticleId, List<int> tagIds)
        {
            var newsArticle = await GetByIdAsync(newsArticleId);
            if (newsArticle == null) return false;

            var tags = await _context.Tags.Where(t => tagIds.Contains(t.TagId)).ToListAsync();
            newsArticle.Tags = tags;

            await _context.SaveChangesAsync();
            return true;
        }
        public List<Tag> GetTagsForArticle(string newsArticleId)
        {
            var article = _context.NewsArticles
                .Include(na => na.Tags)
                .FirstOrDefault(na => na.NewsArticleId == newsArticleId);

            return article?.Tags.ToList() ?? new List<Tag>();
        }

    }


}
