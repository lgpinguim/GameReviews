namespace GameReviews.Domain.Model;

public class Review
{
    public int Id { get; set; }
    public bool Recommended { get; set; }
    public string UserName { get; set; }
    public string ReviewText { get; set; }
    public float HoursPlayed { get; set; }
    public DateTime DatePosted { get; set; }
    public DateTime? DateUpdated { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int GameId { get; set; }
    public Game Game { get; set; }
}

