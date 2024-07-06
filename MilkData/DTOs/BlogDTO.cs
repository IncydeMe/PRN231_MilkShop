namespace MilkData.DTOs;

public class BlogDTO
{
    public int BlogId { get; set; }

    public int BlogCategoryId { get; set; }

    public Guid AccountId { get; set; }

    public string Title { get; set; } = null!;

    public string DocUrl { get; set; } = null!;

    public string? ImageUrl { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? HttpMethod { get; set; }  
}
