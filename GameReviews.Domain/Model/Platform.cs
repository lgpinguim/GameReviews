namespace GameReviews.Domain.Model;

public class Platform
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public ICollection<Game>? Games { get; set; }
}