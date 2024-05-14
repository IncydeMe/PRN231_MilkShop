using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K16231MilkData.Entity
{
    public class Product
    {
        public Product()
        {
            Category = new Category();
            Feedbacks = new List<Feedback>();
            OrderDetails = new List<OrderDetail>();
        }

        [Key]
        public int ProductId { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = null!;
        [Range(0,float.MaxValue)]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; } = null!;
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public string ImageUrl { get; set; } = null!;
        [Range(0,5.0)]
        public decimal TotalRating { get; set; }

        public virtual Category Category { get; set; }
        public virtual List<Feedback> Feedbacks { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}
