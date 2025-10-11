namespace GameReviews.Domain.Model;

public class LanguageSupport
{
    public int Id { get; set; }
    public string Language { get; set; }
    public bool Interface { get; set; }
    public bool Audio { get; set; }
    public bool Subtitles { get; set; }

    public int GameId { get; set; }
    public Game Game { get; set; }
}

