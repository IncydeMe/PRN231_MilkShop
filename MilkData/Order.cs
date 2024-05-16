using System;
using System.Collections.Generic;

namespace MilkData;

public partial class Order
{
    public int OrderId { get; set; }

    public int OrderDetailId { get; set; }

    public int AccountId { get; set; }

    public Guid VoucherCode { get; set; }

    public float TotalPrice { get; set; }

    public string Status { get; set; } = null!;

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
