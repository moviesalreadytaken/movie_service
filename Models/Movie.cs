namespace movie.Models;

public record MovieModel
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public DateOnly ReleaseDate { get; init; }
    public int MinAge { get; init; }
    public string? Description { get; init; }
    public float Rate { get; init; }
    public string Url { get; init; }

    public MovieModel(Guid id, string name, DateOnly releaseDate,
     int minAge, string? description, float rate, string url)
    {
        Id = id;
        Name = name;
        ReleaseDate = releaseDate;
        MinAge = minAge;
        Description = description;
        Rate = rate;
        Url = url;
    }
}