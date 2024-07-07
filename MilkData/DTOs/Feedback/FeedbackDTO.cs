using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkData.DTOs.Feedback
{
    public class FeedbackDTO
    {
        public int FeedbackId { get; set; }

        public int ProductId { get; set; }

        public Guid AccountId { get; set; }

        public int Rating { get; set; }

        public string Content { get; set; }

        public bool IsReported { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
