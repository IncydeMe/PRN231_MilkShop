using System;
using System.Collections.Generic;

namespace MilkData.Models;

public partial class Gifted
{
    public int GiftedId { get; set; }

    public int GiftId { get; set; }

    public Guid AccountId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Gift Gift { get; set; } = null!;
}
