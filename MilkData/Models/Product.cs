using System;
using System.Collections.Generic;

namespace MilkData.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public Guid AccountId { get; set; }

    public int CategoryId { get; set; }

    public int ImageId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int QuantityInStock { get; set; }

    public string? Description { get; set; }

    public string ThumbnailUrl { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ProductImage Image { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
