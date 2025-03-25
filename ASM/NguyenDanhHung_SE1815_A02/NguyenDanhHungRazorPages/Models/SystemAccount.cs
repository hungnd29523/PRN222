using System;
using System.Collections.Generic;

namespace NguyenDanhHungRazorPages.Models;

public partial class SystemAccount
{
    public short AccountId { get; set; }

    public string? AccountName { get; set; }

    public string? AccountEmail { get; set; }

    public int? AccountRole { get; set; }

    public string? AccountPassword { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<NewsArticle> NewsArticles { get; set; } = new List<NewsArticle>();
}
public class AdminAccountSettings
{
    public string Email { get; set; }
    public string Password { get; set; }
    public short AccountId { get; set; }
    public string AccountName { get; set; }
    public int AccountRole { get; set; }
}
