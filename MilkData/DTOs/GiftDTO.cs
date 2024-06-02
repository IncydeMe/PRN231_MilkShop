using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkData.DTOs
{
    public class GiftDTO
    {
        public int GiftId { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public int Point { get; set; }

        public int Quantity { get; set; }

        public string HttpMethod { get; set; }
    }
}
