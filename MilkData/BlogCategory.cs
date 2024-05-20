using System;
using System.Collections.Generic;

namespace MilkData;

public partial class BlogCategory
{
    public int BlogCategoryId { get; set; }

    public string BlogCategoryName { get; set; } = null!;

    public virtual ICollection<Blog1> Blog1s { get; set; } = new List<Blog1>();
}
