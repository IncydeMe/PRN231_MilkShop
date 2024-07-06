using System;
using System.Collections.Generic;

namespace MilkData.Models;

public partial class Account
{
    public Guid AccountId { get; set; }

    public string Role { get; set; }

    public string FullName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string Address { get; set; }

    public string Phone { get; set; }

    public int Point { get; set; }

    public string AvatarUrl { get; set; }

    public bool Disable { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Blog> Blogs { get; set; } = new List<Blog>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Gifted> Gifteds { get; set; } = new List<Gifted>();

    public virtual ICollection<Gift> Gifts { get; set; } = new List<Gift>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
