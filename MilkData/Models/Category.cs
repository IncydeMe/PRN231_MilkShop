using System;
using System.Collections.Generic;

namespace MilkData.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? CategoryCode { get; set; }

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
