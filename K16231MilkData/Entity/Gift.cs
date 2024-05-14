using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K16231MilkData.Entity
{
    public class Gift
    {
        [Key]
        public int GiftId { get; set; }
        [Required]
        [StringLength(int.MaxValue)]
        public string Name { get; set; } = null!;
        [StringLength(int.MaxValue)]
        public string Description { get; set; } = null!;
        [StringLength(int.MaxValue)]
        public string ImageUrl { get; set; } = null!;
        [Range(0, int.MaxValue)]
        public int Point { get; set; }
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
