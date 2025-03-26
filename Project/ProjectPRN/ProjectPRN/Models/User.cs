using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectPRN.Models;

public partial class User
{
    public int Id { get; set; }

    [Required, StringLength(100)]
    public string UserName { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }

    [Required]
    public string PasswordHash { get; set; }

    public string? AvatarUrl { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Follow> FollowFollowers { get; set; } = new List<Follow>();

    public virtual ICollection<Follow> FollowFollowings { get; set; } = new List<Follow>();

    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
public class RegisterViewModel
{
    [Required(ErrorMessage = "Vui lòng nhập tên người dùng.")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập email.")]
    [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
    [MinLength(6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự.")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Vui lòng xác nhận mật khẩu.")]
    [Compare("Password", ErrorMessage = "Mật khẩu không khớp.")]
    public string ConfirmPassword { get; set; }
}