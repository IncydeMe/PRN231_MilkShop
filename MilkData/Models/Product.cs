using System;
using System.Collections.Generic;

namespace MilkData.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public string Description { get; set; } = null!;

    public int ProductCategoryId { get; set; }

    public string ImageUrl { get; set; } = null!;

    public decimal TotalRating { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Category ProductCategory { get; set; } = null!;
}
