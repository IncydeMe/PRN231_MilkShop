using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K16231MilkData.Entity
{
    public class Order
    {
        public Order()
        {
            Details = new List<OrderDetail>();
            Account = new Account();
        }

        [Key]
        public int OrderId { get; set; }
        [ForeignKey("OrderDetailId")]
        public int OrderDetailId { get; set; }
        [ForeignKey("AccountId")]
        public int AccountId { get; set; }
        public Guid VoucherCode { get; set; }
        [Range(0, float.MaxValue)]
        public float TotalPrice { get; set; }
        [StringLength(20)]
        public string Status { get; set; } = null!;

        public virtual List<OrderDetail> Details { get; set; }
        public virtual Account Account { get; set; }
    }
}
