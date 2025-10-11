namespace GameReviews.Domain.Model;

public class Game
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public DateTime ReleaseDate { get; set; }
    public decimal Price { get; set; }
    public string? CoverImageUrl { get; set; }
    public string? TrailerUrl { get; set; }
    public int? MetacriticScore { get; set; }
    public ICollection<Platform>? Platforms { get; set; }
    public bool IsEarlyAccess { get; set; }
    public string? AgeRating { get; set; } // ESRB/PEGI
    public DateTime? LastUpdated { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public required ICollection<Developer> Developers { get; set; }
    public required ICollection<Publisher> Publishers { get; set; }
    public required ICollection<Category> Categories { get; set; }
    public required ICollection<LanguageSupport> LanguageSupport { get; set; }
    public ICollection<Achievement>? Achievements { get; set; }
    public ICollection<Review>? Reviews { get; set; }
}

