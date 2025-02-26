using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NguyenDanhHungMVC.Models;

public partial class NewsArticle
{
    public string NewsArticleId { get; set; }

    [Required(ErrorMessage = "Title is required")]
    public string? NewsTitle { get; set; }

    public string Headline { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }
    [Required(ErrorMessage = "Content is required")]
    public string? NewsContent { get; set; }

    public string? NewsSource { get; set; }

    public short? CategoryId { get; set; }

    public bool? NewsStatus { get; set; }

    public short? CreatedById { get; set; }

    public short? UpdatedById { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual Category? Category { get; set; }

    public virtual SystemAccount? CreatedBy { get; set; }

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();

    public NewsArticle()
    {
        NewsArticleId = GenerateShortId();
    }

    private string GenerateShortId()
    {
        return Guid.NewGuid().ToString("N").Substring(0, 20);
    }
}
