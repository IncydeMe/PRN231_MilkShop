using System;
using System.Collections.Generic;

namespace MilkData.Models;

public partial class Gift
{
    public int GiftId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;

    public int Point { get; set; }

    public int Quantity { get; set; }
}
