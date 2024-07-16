using System;
using System.Collections.Generic;

namespace MilkData.Models;

public partial class Feedback
{
    public int FeedbackId { get; set; }

    public int AccountId { get; set; }

    public int ProductId { get; set; }

    public string? Description { get; set; }

    public string? FeedbackContent { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdateDate { get; set; }

    public int? Rating { get; set; }

    public string? Status { get; set; }

    public string? Type { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<FeedbackMedia> FeedbackMedia { get; set; } = new List<FeedbackMedia>();

    public virtual Product Product { get; set; } = null!;
}
