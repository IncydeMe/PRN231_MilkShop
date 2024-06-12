using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkData.DTOs
{
    public class FeedbackDTO
    {
        public int FeedbackId { get; set; }

        public int AccountId { get; set; }

        public int ProductId { get; set; }

        public string Content { get; set; } = null!;

        public DateTime CreatedDate { get; set; }

        public int Rating { get; set; }

        public string? HttpMethod { get; set; }
    }
}
