using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NguyenDanhHungMVC.Models;

public partial class SystemAccount
{
    public short AccountId { get; set; }

    public string? AccountName { get; set; }

    public string? AccountEmail { get; set; }

    public int? AccountRole { get; set; }

    public string? AccountPassword { get; set; }
    public bool? IsActive { get; set; }

    public virtual ICollection<NewsArticle> NewsArticles { get; set; } = new List<NewsArticle>();
    public string RoleName => AccountRole switch
    {
        1 => "Staff",
        2 => "Lecturer",
        _ => "Unknown"
    };
}
public class AdminAccountSettings
{
    public string Email { get; set; }
    public string Password { get; set; }
}
public class EditProfileViewModel
{
    public string AccountName { get; set; } = string.Empty;
    public string? NewPassword { get; set; }
}
