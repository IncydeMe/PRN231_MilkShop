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

        public int AccountId { get; set; }

        public int ProductId { get; set; }

        public string? Description { get; set; }

        public string? FeedbackContent { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public int? Rating { get; set; }

        public string? Status { get; set; }

        public string? Type { get; set; }
    }
}
