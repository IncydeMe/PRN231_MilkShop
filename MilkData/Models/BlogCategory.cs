using System;
using System.Collections.Generic;

namespace MilkData.Models;

public partial class BlogCategory
{
    public int BlogCategoryId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Blog> Blogs { get; set; } = new List<Blog>();
}
