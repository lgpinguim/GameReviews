namespace GameReviews.Domain.Model;

public class Review
{
    public int Id { get; set; }
    public bool Recommended { get; set; }
    public required string UserName { get; set; }
    public required string ReviewText { get; set; }
    public float HoursPlayed { get; set; }
    public DateTime DatePosted { get; set; }
    public DateTime? DateUpdated { get; set; }
    public int HelpfulCount { get; set; } // upvotes
    public int UnhelpfulCount { get; set; } // downvotes
    public bool ReceivedForFree { get; set; }
    public bool EarlyAccessReview { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int UserId { get; set; }
    public required User User { get; set; }
    public int GameId { get; set; }
    public required Game Game { get; set; }
}

