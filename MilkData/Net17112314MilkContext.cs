using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MilkData;

public partial class Net17112314MilkContext : DbContext
{
    public Net17112314MilkContext()
    {
    }

    public Net17112314MilkContext(DbContextOptions<Net17112314MilkContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Blog> Blogs { get; set; }

    public virtual DbSet<BlogCategory> BlogCategories { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<FeedbackMedia> FeedbackMedias { get; set; }

    public virtual DbSet<Gift> Gifts { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Voucher> Vouchers { get; set; }

    private string GetConnectionString()
    {
        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
        var strConn = config["ConnectionStrings:DefaultConnectionString"];
        return strConn;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(GetConnectionString());

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.Property(e => e.Address).IsRequired();
            entity.Property(e => e.Email).IsRequired();
            entity.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.Phone).IsRequired();
            entity.Property(e => e.Role)
                .IsRequired()
                .HasMaxLength(10);
        });

        modelBuilder.Entity<Blog>(entity =>
        {
            entity.HasIndex(e => e.AccountId, "IX_Blogs_AccountId");

            entity.HasIndex(e => e.BlogCategoryId, "IX_Blogs_BlogCategoryId");

            entity.Property(e => e.Content).IsRequired();
            entity.Property(e => e.ImageUrl).IsRequired();
            entity.Property(e => e.ProductSuggestUrl).IsRequired();
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasOne(d => d.Account).WithMany(p => p.Blogs).HasForeignKey(d => d.AccountId);

            entity.HasOne(d => d.BlogCategory).WithMany(p => p.Blogs).HasForeignKey(d => d.BlogCategoryId);
        });

        modelBuilder.Entity<BlogCategory>(entity =>
        {
            entity.Property(e => e.BlogCategoryName)
                .IsRequired()
                .HasMaxLength(30);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.CategoryName)
                .IsRequired()
                .HasMaxLength(30);
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasIndex(e => e.AccountId, "IX_Feedbacks_AccountId");

            entity.HasIndex(e => e.ProductId, "IX_Feedbacks_ProductId");

            entity.Property(e => e.Content).IsRequired();

            entity.HasOne(d => d.Account).WithMany(p => p.Feedbacks).HasForeignKey(d => d.AccountId);

            entity.HasOne(d => d.Product).WithMany(p => p.Feedbacks).HasForeignKey(d => d.ProductId);
        });

        modelBuilder.Entity<FeedbackMedia>(entity =>
        {
            entity.HasIndex(e => e.FeedbackId, "IX_FeedbackMedias_FeedbackId");

            entity.Property(e => e.MediaType)
                .IsRequired()
                .HasMaxLength(10);
            entity.Property(e => e.MediaUrl).IsRequired();

            entity.HasOne(d => d.Feedback).WithMany(p => p.FeedbackMedia).HasForeignKey(d => d.FeedbackId);
        });

        modelBuilder.Entity<Gift>(entity =>
        {
            entity.Property(e => e.Description).IsRequired();
            entity.Property(e => e.ImageUrl).IsRequired();
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasIndex(e => e.AccountId, "IX_Orders_AccountId");

            entity.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(20);

            entity.HasOne(d => d.Account).WithMany(p => p.Orders).HasForeignKey(d => d.AccountId);
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasIndex(e => e.OrderId, "IX_OrderDetails_OrderId");

            entity.HasIndex(e => e.ProductId, "IX_OrderDetails_ProductId");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails).HasForeignKey(d => d.OrderId);

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails).HasForeignKey(d => d.ProductId);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasIndex(e => e.CategoryId, "IX_Products_CategoryId");

            entity.Property(e => e.Description).IsRequired();
            entity.Property(e => e.ImageUrl).IsRequired();
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalRating).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Category).WithMany(p => p.Products).HasForeignKey(d => d.CategoryId);
        });

        modelBuilder.Entity<Voucher>(entity =>
        {
            entity.Property(e => e.VoucherId).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
