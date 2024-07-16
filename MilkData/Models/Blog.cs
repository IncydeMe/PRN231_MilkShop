using System;
using System.Collections.Generic;

namespace MilkData.Models;

public partial class Blog
{
    public int BlogId { get; set; }

    public int AccountId { get; set; }

    public string Title { get; set; } = null!;

    public string? BlogContent { get; set; }

    public string? ImageUrl { get; set; }

    public string? ProductSuggestUrl { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string? CategoryName { get; set; }

    public string? Reference { get; set; }

    public int? Priority { get; set; }

    public virtual Account Account { get; set; } = null!;
}
