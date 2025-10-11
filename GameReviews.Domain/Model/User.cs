namespace GameReviews.Domain.Model;

public class User
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public string? ProfilePictureUrl { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int TotalReviews { get; set; }
    public ICollection<Review>? Reviews { get; set; }
}

