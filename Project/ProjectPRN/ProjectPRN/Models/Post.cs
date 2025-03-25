using System;
using System.Collections.Generic;

namespace ProjectPRN.Models;

public partial class Post
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string? Caption { get; set; }

    public int? Privacy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();
}
