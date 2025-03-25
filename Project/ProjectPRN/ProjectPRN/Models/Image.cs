using System;
using System.Collections.Generic;

namespace ProjectPRN.Models;

public partial class Image
{
    public int Id { get; set; }

    public string ImageUrl { get; set; } = null!;

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
