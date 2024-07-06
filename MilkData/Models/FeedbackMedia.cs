using System;
using System.Collections.Generic;

namespace MilkData.Models;

public partial class FeedbackMedia
{
    public int FeedbackMediaId { get; set; }

    public string MediaUrl { get; set; } = null!;

    public string MediaType { get; set; } = null!;

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
}
