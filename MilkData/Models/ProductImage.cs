using System;
using System.Collections.Generic;

namespace MilkData.Models;

public partial class ProductImage
{
    public int ImageId { get; set; }

    public string Url { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
