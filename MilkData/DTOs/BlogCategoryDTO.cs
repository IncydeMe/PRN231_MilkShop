namespace MilkData.DTOs;

public class BlogCategoryDTO
{
	public int BlogCategoryId { get; set; }

	public string Name { get; set; } = null!;
	
	public string? HttpMethod { get; set; }
}
