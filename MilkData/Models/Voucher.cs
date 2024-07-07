using System;
using System.Collections.Generic;

namespace MilkData.Models;

public partial class Voucher
{
    public int VoucherId { get; set; }

    public int Value { get; set; }

    public string Type { get; set; }

    public string Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string Status { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
