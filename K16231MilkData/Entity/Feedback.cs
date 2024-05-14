using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K16231MilkData.Entity
{
    public class Feedback
    {
        public Feedback()
        {
            Account = new Account();
            Product = new Product();
            Media = new List<FeedbackMedia>();
        }
        [Key]
        public int FeedbackId { get; set; }
        [ForeignKey("AccountId")]
        public int AccountId { get; set; }
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        [StringLength(int.MaxValue)]
        public string Content { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public int Rating { get; set; }

        public virtual Account Account { get; set; }
        public virtual Product Product { get; set; }
        public virtual List<FeedbackMedia> Media { get; set; }
    }
}
