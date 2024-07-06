using System;
using System.Collections.Generic;

namespace MilkData.Models;

public partial class Feedback
{
    public int FeedbackId { get; set; }

    public int ProductId { get; set; }

    public Guid AccountId { get; set; }

    public int Rating { get; set; }

    public string Content { get; set; }

    public bool IsReported { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Account Account { get; set; }

    public virtual ICollection<FeedbackMedia> FeedbackMedia { get; set; } = new List<FeedbackMedia>();

    public virtual Product Product { get; set; }
}
