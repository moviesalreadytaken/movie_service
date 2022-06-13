using Microsoft.EntityFrameworkCore;

namespace movie.Models;

public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> options) : base(options)
    {
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