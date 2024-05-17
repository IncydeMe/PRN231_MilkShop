using System;
using System.Collections.Generic;

namespace MilkData;

public partial class BlogCategory
{
    public int BlogCategoryId { get; set; }

    public string BlogCategoryName { get; set; }

    public virtual ICollection<Blog> Blogs { get; set; } = new List<Blog>();
}
