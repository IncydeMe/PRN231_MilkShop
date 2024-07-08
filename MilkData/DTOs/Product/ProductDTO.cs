using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkData.DTOs.Product
{
    public class ProductDTO
    {
        public int ProductId { get; set; }

        public Guid AccountId { get; set; }

        public int CategoryId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int QuantityInStock { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int TotalRating { get; set; }
    }
}
