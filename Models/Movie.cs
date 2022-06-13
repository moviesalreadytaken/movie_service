using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using movie.Utils;
using Newtonsoft.Json;

namespace movie.Models;

public class MovieModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public Guid ID { get; set; }
    [Required]
    [MinLength(1)]
    public string Name { get; set; }
    [Required]
    [JsonConverter(typeof(DateOnlyConverter))]
    public DateOnly ReleaseDate { get; set; }
    [Required]
    [Range(0, int.MaxValue)]
    public int MinAge { get; set; }
    public string? Description { get; set; }
    [Required]
    [Range(0, 5)]
    public float Rate { get; set; }
    [Url]
    public string? Url { get; set; }

    public MovieModel(Guid iD, string name, DateOnly releaseDate,
     int minAge, string? description, float rate, string? url)
    {
        ID = iD;
        Name = name;
        ReleaseDate = releaseDate;
        MinAge = minAge;
        Description = description;
        Rate = rate;
        Url = url;
    }
}