using Microsoft.EntityFrameworkCore;
using NguyenDanhHungMVC.Models;
using NguyenDanhHungMVC.Repositories;
using NuGet.Protocol.Core.Types;

namespace NguyenDanhHungMVC.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
                }

        public List<Tag> GetAllTags() => _tagRepository.GetAllTags();

        public List<Tag> GetTagsForArticle(string articleId) => _tagRepository.GetTagsForArticle(articleId);

        public void AddTagToArticle(string articleId, int tagId) => _tagRepository.AddTagToArticle(articleId, tagId);

        public void RemoveTagFromArticle(string articleId, int tagId) => _tagRepository.RemoveTagFromArticle(articleId, tagId);

        public void UpdateTagsForArticle(string articleId, List<int> tagIds)
        {
            _tagRepository.UpdateTagsForArticle(articleId, tagIds);
        }


    }

}
