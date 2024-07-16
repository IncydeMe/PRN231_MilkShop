using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkData.DTOs.FeedbackMedia
{
    public class FeedbackMediaDTO
    {
        public int FeedbackMediaId { get; set; }

        public int FeedbackId { get; set; }

        public string MediaUrl { get; set; } = null!;

        public string MediaType { get; set; } = null!;

        public DateTime? CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}
