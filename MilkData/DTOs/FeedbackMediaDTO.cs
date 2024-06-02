using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkData.DTOs
{
    public class FeedbackMediaDTO
    {
        public int FeedbackMediaId { get; set; }

        public string MediaUrl { get; set; } = null!;

        public string MediaType { get; set; } = null!;

        public int FeedbackId { get; set; }

        public string HttpMethod { get; set; }
    }
}
