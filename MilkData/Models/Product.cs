using System;
using System.Collections.Generic;

namespace MilkData.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public Guid AccountId { get; set; }

    public int CategoryId { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public int QuantityInStock { get; set; }

    public string Description { get; set; }

    public string Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int TotalRating { get; set; }

    public virtual Account Account { get; set; }

    public virtual Category Category { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
}
