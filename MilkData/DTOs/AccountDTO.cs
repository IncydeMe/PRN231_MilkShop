using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkData.DTOs
{
    public class AccountDTO
    {
        public Guid AccountId { get; set; }
        public int RoleId { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateOnly? DateOfBirth { get; set; }
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public int Point { get; set; }
        public bool Disable { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? HttpMethod { get; set; }
    }

    public class LoginDTO
    {
        public Guid Id { get; set; }
        public int RoleId { get; set; }
        public string Token { get; set; } = null!;
    }
}
