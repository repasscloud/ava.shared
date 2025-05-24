namespace Ava.Shared.Models.Policies;

[Index(nameof(Name), IsUnique = true)]
public class Region
{
    public int Id { get; set; }
    
    [Required]
    public required string Name { get; set; }

    // a region contains one or more continents
    public ICollection<Continent> Continents { get; set; } = new List<Continent>();
}
