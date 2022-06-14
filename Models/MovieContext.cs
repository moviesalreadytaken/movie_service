using Microsoft.EntityFrameworkCore;

namespace movie.Models;

public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> options) : base(options)
    {
        if (!MovieModels.Any())
        {
            Add(new MovieModel(Guid.Empty, "Some film1", new DateOnly(2000, 10, 10), 13, "some film description", 4.6f, null));
            Add(new MovieModel(Guid.Empty, "Some film2", new DateOnly(2001, 10, 10), 0, "some film description", 4.9f, null));
            Add(new MovieModel(Guid.Empty, "Some film3", new DateOnly(2002, 10, 10), 16, "some film description", 3f, null));
            Add(new MovieModel(Guid.Empty, "Some film4", new DateOnly(2003, 10, 10), 18, "some film description", 4f, null));
            Add(new MovieModel(Guid.Empty, "Some film5", new DateOnly(2004, 10, 10), 21, "some film description", 4.1f, null));
            Add(new MovieModel(Guid.Empty, "Some film6", new DateOnly(2005, 10, 10), 13, "some film description", 2.5f, null));
            Add(new MovieModel(Guid.Empty, "Some film7", new DateOnly(2006, 10, 10), 16, "some film description", 4.1f, null));
            Add(new MovieModel(Guid.Empty, "Some film8", new DateOnly(2007, 10, 10), 0, "some film description", 1f, null));
            SaveChanges();
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MovieModel>(mov =>
            mov.HasKey(m => m.ID)
        );
        base.OnModelCreating(modelBuilder);
    }
    public DbSet<MovieModel> MovieModels { get; set; } = null!;
}