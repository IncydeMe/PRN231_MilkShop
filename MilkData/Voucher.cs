using System;
using System.Collections.Generic;

namespace MilkData;

public partial class Voucher
{
    public Guid VoucherId { get; set; }

    public int Value { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }
}
