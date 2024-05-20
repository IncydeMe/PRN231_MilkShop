﻿using System;
using System.Collections.Generic;

namespace MilkData;

public partial class Blog
{
    public int BlogId { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;

    public string ProductSuggestUrl { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public int AccountId { get; set; }

    public virtual Account Account { get; set; } = null!;
}
