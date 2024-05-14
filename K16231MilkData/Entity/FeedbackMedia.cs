using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K16231MilkData.Entity
{
    public class FeedbackMedia
    {
        public FeedbackMedia()
        {
            Feedback = new Feedback();
        }

        public int FeedbackMediaId { get; set; }
        public string MediaUrl { get; set; } = null!;
        public string MediaType { get; set; } = null!;

        public virtual Feedback Feedback { get; set; }
    }
}
