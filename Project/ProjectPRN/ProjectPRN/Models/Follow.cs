﻿using System;
using System.Collections.Generic;

namespace ProjectPRN.Models;

public partial class Follow
{
    public int FollowerId { get; set; }

    public int FollowingId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User Follower { get; set; } = null!;

    public virtual User Following { get; set; } = null!;
}
