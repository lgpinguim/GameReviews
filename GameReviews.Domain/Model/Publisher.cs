namespace GameReviews.Domain.Model;

public class Publisher
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Game> Games { get; set; }
}

