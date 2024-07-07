using System;
using System.Collections.Generic;

namespace MilkData.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int VoucherId { get; set; }

    public Guid AccountId { get; set; }

    public string Status { get; set; }

    public decimal? OrderPrice { get; set; }

    public virtual Account Account { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Voucher Voucher { get; set; }
}
