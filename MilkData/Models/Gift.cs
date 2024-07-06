﻿using System;
using System.Collections.Generic;

namespace MilkData.Models;

public partial class Gift
{
    public int GiftId { get; set; }

    public Guid AccountId { get; set; }

    public string Name { get; set; } = null!;

    public int Quantity { get; set; }

    public string Description { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;

    public int Point { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<Gifted> Gifteds { get; set; } = new List<Gifted>();
}
