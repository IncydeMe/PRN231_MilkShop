using System;
using System.Collections.Generic;

namespace MilkData.Models;

public partial class OrderDetail
{
    public int OrderDetailId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal TotalPrice { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Product Product { get; set; } = null!;
}
