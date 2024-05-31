﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MilkData.Models;

public partial class OrderDetail
{
    public int OrderDetailId { get; set; }

    public int Quantity { get; set; }

    public int ProductId { get; set; }

    public int OrderId { get; set; }

    [JsonIgnore]
    public virtual Order Order { get; set; } = null!;

    [JsonIgnore]
    public virtual Product Product { get; set; } = null!;
}
