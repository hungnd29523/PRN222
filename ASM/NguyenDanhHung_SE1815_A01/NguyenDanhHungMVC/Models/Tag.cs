using System;
using System.Collections.Generic;

namespace NguyenDanhHungMVC.Models;

public partial class Tag
{
    public int TagId { get; set; }

    public string? TagName { get; set; }

    public string? Note { get; set; }

    public virtual ICollection<NewsArticle> NewsArticles { get; set; } = new List<NewsArticle>();
}
public class TagSelectionViewModel
{
    public string NewsArticleId { get; set; }
    public List<Tag> AllTags { get; set; } = new();
    public List<int> SelectedTagIds { get; set; } = new();
}
