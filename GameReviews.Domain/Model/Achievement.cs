namespace GameReviews.Domain.Model;

public class Achievement
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int GameId { get; set; }
    public Game Game { get; set; }
}

