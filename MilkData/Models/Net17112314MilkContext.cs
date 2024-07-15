using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MilkData.Models;

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

    public virtual DbSet<Gifted> Gifteds { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductImage> ProductImages { get; set; }

    public virtual DbSet<Voucher> Vouchers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(GetConnectionString());

    private static string GetConnectionString()
    {
        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();
        return config.GetConnectionString("DefaultConnection") ?? throw new Exception("'DefaultConnection' doesn't exists in 'appsettings.json'");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.Property(e => e.AccountId)
                .ValueGeneratedNever()
                .HasColumnName("accountId");
            entity.Property(e => e.Address)
                .IsRequired()
                .HasColumnName("address");
            entity.Property(e => e.AvatarUrl)
                .IsUnicode(false)
                .HasColumnName("avatarUrl");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.DateOfBirth).HasColumnName("dateOfBirth");
            entity.Property(e => e.Disable).HasColumnName("disable");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("fullName");
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Point).HasColumnName("point");
            entity.Property(e => e.Role)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("role");
        });

        modelBuilder.Entity<Blog>(entity =>
        {
            entity.Property(e => e.BlogId)
                .ValueGeneratedNever()
                .HasColumnName("blogId");
            entity.Property(e => e.AccountId).HasColumnName("accountId");
            entity.Property(e => e.BlogCategoryId).HasColumnName("blogCategoryId");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.DocUrl)
                .IsRequired()
                .IsUnicode(false)
                .HasColumnName("docUrl");
            entity.Property(e => e.ImageUrl)
                .IsUnicode(false)
                .HasColumnName("imageUrl");
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.Account).WithMany(p => p.Blogs)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Blogs_Accounts");

            entity.HasOne(d => d.BlogCategory).WithMany(p => p.Blogs)
                .HasForeignKey(d => d.BlogCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Blogs_BlogCategories");
        });

        modelBuilder.Entity<BlogCategory>(entity =>
        {
            entity.Property(e => e.BlogCategoryId)
                .ValueGeneratedNever()
                .HasColumnName("blogCategoryId");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.CategoryId)
                .ValueGeneratedNever()
                .HasColumnName("categoryId");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.Property(e => e.FeedbackId)
                .ValueGeneratedNever()
                .HasColumnName("feedbackId");
            entity.Property(e => e.AccountId).HasColumnName("accountId");
            entity.Property(e => e.Content)
                .IsRequired()
                .HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.IsReported).HasColumnName("isReported");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.Account).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Feedbacks_Accounts");

            entity.HasOne(d => d.Product).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Feedbacks_Products");
        });

        modelBuilder.Entity<FeedbackMedia>(entity =>
        {
            entity.Property(e => e.FeedbackMediaId).HasColumnName("feedbackMediaId");
            entity.Property(e => e.FeedbackId).HasColumnName("feedbackId");
            entity.Property(e => e.MediaType)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("mediaType");
            entity.Property(e => e.MediaUrl)
                .IsRequired()
                .IsUnicode(false)
                .HasColumnName("mediaUrl");

            entity.HasOne(d => d.Feedback).WithMany(p => p.FeedbackMedia)
                .HasForeignKey(d => d.FeedbackId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FeedbackMedias_Feedbacks");
        });

        modelBuilder.Entity<Gift>(entity =>
        {
            entity.Property(e => e.GiftId).HasColumnName("giftId");
            entity.Property(e => e.AccountId).HasColumnName("accountId");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Description)
                .IsRequired()
                .HasColumnName("description");
            entity.Property(e => e.ImageUrl)
                .IsRequired()
                .IsUnicode(false)
                .HasColumnName("imageUrl");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("name");
            entity.Property(e => e.Point).HasColumnName("point");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.Account).WithMany(p => p.Gifts)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Gifts_Accounts");
        });

        modelBuilder.Entity<Gifted>(entity =>
        {
            entity.ToTable("Gifted");

            entity.Property(e => e.GiftedId)
                .ValueGeneratedNever()
                .HasColumnName("giftedId");
            entity.Property(e => e.AccountId).HasColumnName("accountId");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.GiftId).HasColumnName("giftId");
            entity.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("status");

            entity.HasOne(d => d.Account).WithMany(p => p.Gifteds)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Gifted_Accounts");

            entity.HasOne(d => d.Gift).WithMany(p => p.Gifteds)
                .HasForeignKey(d => d.GiftId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Gifted_Gifts");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.OrderId)
                .ValueGeneratedNever()
                .HasColumnName("orderId");
            entity.Property(e => e.AccountId).HasColumnName("accountId");
            entity.Property(e => e.OrderPrice)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("orderPrice");
            entity.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.VoucherId).HasColumnName("voucherId");

            entity.HasOne(d => d.Account).WithMany(p => p.Orders)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Accounts");

            entity.HasOne(d => d.Voucher).WithMany(p => p.Orders)
                .HasForeignKey(d => d.VoucherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Vouchers");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.Property(e => e.OrderDetailId)
                .ValueGeneratedNever()
                .HasColumnName("orderDetailId");
            entity.Property(e => e.OrderId).HasColumnName("orderId");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetails_Orders");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetails_Products");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnName("productId");
            entity.Property(e => e.AccountId).HasColumnName("accountId");
            entity.Property(e => e.CategoryId).HasColumnName("categoryId");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("price");
            entity.Property(e => e.QuantityInStock).HasColumnName("quantityInStock");
            entity.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.TotalRating).HasColumnName("totalRating");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.Account).WithMany(p => p.Products)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Accounts");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Categories");
        });

        modelBuilder.Entity<ProductImage>(entity =>
        {
            entity.HasKey(e => e.ImageId);

            entity.Property(e => e.ImageId)
                .ValueGeneratedNever()
                .HasColumnName("imageId");
            entity.Property(e => e.IsThumbnail).HasColumnName("isThumbnail");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.Url)
                .IsRequired()
                .IsUnicode(false)
                .HasColumnName("url");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductImages)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductImages_Products");
        });

        modelBuilder.Entity<Voucher>(entity =>
        {
            entity.Property(e => e.VoucherId)
                .ValueGeneratedNever()
                .HasColumnName("voucherId");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("endDate");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("startDate");
            entity.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("type");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
