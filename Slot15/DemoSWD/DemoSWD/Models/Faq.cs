using System;
using System.Collections.Generic;

namespace DemoSWD.Models;

public partial class Faq
{
    public int Id { get; set; }

    public string Question { get; set; } = null!;

    public string? Answer { get; set; }
}
