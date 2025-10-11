namespace GameReviews.Domain.Model;

public class LanguageSupport
{
    public int Id { get; set; }
    public required string Language { get; set; }
    public bool Interface { get; set; }
    public bool Audio { get; set; }
    public bool Subtitles { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int GameId { get; set; }
    public required Game Game { get; set; }
}

