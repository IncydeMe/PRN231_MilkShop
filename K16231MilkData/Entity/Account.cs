using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K16231MilkData.Entity
{
    public class Account
    {
        public Account()
        {
            Feedbacks = new List<Feedback>();
            Blogs = new List<Blog>();
            Orders = new List<Order>();
        }

        [Key]
        public int AccountId { get; set; }
        [StringLength(50)]
        public string FullName { get; set; } = null!;
        [EmailAddress]
        [Required]
        public string Email { get; set; } = null!;
        [StringLength(16)]
        [Required]
        public string Password { get; set; } = null!;
        [Phone]
        public string Phone { get; set; } = null!;
        [StringLength(int.MaxValue)]
        public string Address { get; set; } = null!;
        [Required]
        public string Role { get; set; } = null!;
        [Range(0, int.MaxValue)]
        public int Point { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; }

        public virtual List<Feedback> Feedbacks { get; set; }
        public virtual List<Blog> Blogs { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
