using System;
using System.Collections.Generic;

namespace MilkData.Models;

public partial class Feedback
{
    public int FeedbackId { get; set; }

    public int ProductId { get; set; }

    public Guid AccountId { get; set; }

    public int FeedbackMediaId { get; set; }

    public int Rating { get; set; }

    public string Content { get; set; } = null!;

    public bool IsReported { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual FeedbackMedia FeedbackMedia { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
