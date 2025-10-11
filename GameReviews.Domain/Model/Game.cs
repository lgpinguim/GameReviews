namespace GameReviews.Domain.Model;

public class Game
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime ReleaseDate { get; set; }
    public ICollection<Developer> Developers { get; set; }
    public ICollection<Publisher> Publishers { get; set; }
    public ICollection<Category> Categories { get; set; }
    public ICollection<LanguageSupport> LanguageSupport { get; set; }
    public ICollection<Achievement> Achievements { get; set; }
    public ICollection<Review> Reviews { get; set; }
}

