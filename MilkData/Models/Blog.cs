using System;
using System.Collections.Generic;

namespace MilkData.Models;

public partial class Blog
{
    public int BlogId { get; set; }

    public int BlogCategoryId { get; set; }

    public Guid AccountId { get; set; }

    public string Title { get; set; }

    public string DocUrl { get; set; }

    public string ImageUrl { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Account Account { get; set; }

    public virtual BlogCategory BlogCategory { get; set; }
}
