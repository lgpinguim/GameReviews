namespace GameReviews.Domain.Model;

public class Achievement
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public string? IconUrl { get; set; }
    public decimal UnlockPercentage { get; set; } // % of players who unlocked it
    public bool IsHidden { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int GameId { get; set; }
    public required Game Game { get; set; }
}

