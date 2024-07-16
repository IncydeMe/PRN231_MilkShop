using System;
using System.Collections.Generic;

namespace MilkData.Models;

public partial class Account
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

    public virtual ICollection<Blog> Blogs { get; set; } = new List<Blog>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
