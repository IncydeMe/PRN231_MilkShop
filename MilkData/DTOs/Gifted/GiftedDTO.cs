namespace MilkData.DTOs.Gifted;

public class GiftedDTO {
    public int GiftedId { get; set; }

    public int GiftId { get; set; }

    public Guid AccountId { get; set; }

    public string Status { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
}
