using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K16231MilkData.Entity
{
    public class Blog
    {
        public Blog()
        {
            Account = new Account();
        }

        [Key]
        public int BlogId { get; set; }
        [StringLength(int.MaxValue)]
        [Required]
        public string Title { get; set; } = null!;
        [StringLength(int.MaxValue)]
        [Required]
        public string Content { get; set; } = null!;
        [StringLength(int.MaxValue)]
        [Required]
        public string ImageUrl { get; set; } = null!;
        [StringLength(int.MaxValue)]
        public string ProductSuggestUrl { get; set; } = null!;
        public DateTime CreatedDate { get; set; }

        public virtual Account Account { get; set; }
    }
}
