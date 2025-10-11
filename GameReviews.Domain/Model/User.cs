namespace GameReviews.Domain.Model;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Review> Reviews { get; set; }
}

