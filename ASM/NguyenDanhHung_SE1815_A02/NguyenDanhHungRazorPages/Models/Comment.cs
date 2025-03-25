using System;
using System.Collections.Generic;

namespace NguyenDanhHungRazorPages.Models;

public partial class Comment
{
    public int Id { get; set; }

    public string NewsId { get; set; } = null!;

    public short UserId { get; set; }

    public string Content { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual NewsArticle News { get; set; } = null!;

    public virtual SystemAccount User { get; set; } = null!;
}
