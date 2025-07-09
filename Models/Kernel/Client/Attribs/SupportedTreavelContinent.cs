namespace Ava.Shared.Models.Kernel.Client.Attribs;

public class SupportedTravelContinent
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Continent { get; set; }
}
