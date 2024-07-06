using System;
using System.Collections.Generic;

namespace MilkData.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int VoucherId { get; set; }

    public Guid AccountId { get; set; }

    public int OrderDetailId { get; set; }

    public string Status { get; set; } = null!;

    public virtual Account Account { get; set; } = null!;

    public virtual OrderDetail OrderDetail { get; set; } = null!;

    public virtual Voucher Voucher { get; set; } = null!;
}
