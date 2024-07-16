using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkData.DTOs.Account
{
    public class AccountDTO
    {
        public int AccountId { get; set; }

        public string? UserName { get; set; }

        public string? FullName { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public string Role { get; set; } = null!;

        public int Point { get; set; }

        public string? AvatarUrl { get; set; }

        public bool? IsActive { get; set; }
    }
}
