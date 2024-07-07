using System;
using System.Collections.Generic;

namespace MilkData.Models;

public partial class Gift
{
    public int GiftId { get; set; }

    public Guid AccountId { get; set; }

    public string Name { get; set; }

    public int Quantity { get; set; }

    public string Description { get; set; }

    public string ImageUrl { get; set; }

    public int Point { get; set; }

    public string Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Account Account { get; set; }

    public virtual ICollection<Gifted> Gifteds { get; set; } = new List<Gifted>();
}
