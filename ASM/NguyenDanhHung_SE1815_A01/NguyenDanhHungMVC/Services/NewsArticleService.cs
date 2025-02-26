using Microsoft.EntityFrameworkCore;
using NguyenDanhHungMVC.Data;
using NguyenDanhHungMVC.Models;
using NguyenDanhHungMVC.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace NguyenDanhHungMVC.Services
{

    public class NewsArticleService : INewsArticleService
    {
        private readonly INewsArticleRepository _newsArticleRepository;
        private readonly ICategoryService _categoryService;

        public NewsArticleService(INewsArticleRepository newsArticleRepository,ICategoryService categoryService)
        {
            _newsArticleRepository = newsArticleRepository;
            _categoryService = categoryService;
        }

        public async Task<IEnumerable<NewsArticle>> GetAllNewsAsync()
        {
            return await _newsArticleRepository.GetAllAsync();
        }
        public async Task<IEnumerable<NewsArticle>> GetNewsActiveAsync()
        {
            return await _newsArticleRepository.GetNewsActiveAsync();
        }




        public async Task<NewsArticle?> GetNewsByIdAsync(string id)
        {
            return await _newsArticleRepository.GetByIdAsync(id);
        }

        public async Task AddNewsAsync(NewsArticle article)
        {
            await _newsArticleRepository.AddAsync(article);
        }

        public async Task DeleteNewsAsync(string id)
        {
            await _newsArticleRepository.DeleteAsync(id);
        }
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _categoryService.GetAllCategoriesAsync(); 
        }
        public async Task<string?> GetAccountNameByIdAsync(short? accountId)
        {
            return await _newsArticleRepository.GetAccountNameByIdAsync(accountId);
        }
        public async Task<string?> GetCreatedByNameAsync(short? createdById)
        {
            return await _newsArticleRepository.GetCreatedByNameAsync(createdById);
        }
        public async Task UpdateNewsAsync(NewsArticle article)
        {
            await _newsArticleRepository.UpdateAsync(article);
        }
        public async Task<bool> IsCategoryUsedAsync(short categoryId)
        {
            return await _newsArticleRepository.IsCategoryUsedAsync(categoryId);
        }

        public async Task<bool> AddTagsToNewsArticleAsync(string newsArticleId, List<int> tagIds)
        {
            return await _newsArticleRepository.AddTagsToNewsArticleAsync(newsArticleId, tagIds);
        }
        public List<Tag> GetTagsForArticle(string newsArticleId)
        {
            return _newsArticleRepository.GetTagsForArticle(newsArticleId);
        }


    }

}
