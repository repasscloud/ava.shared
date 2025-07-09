namespace Ava.Shared.Models.Kernel.Client.Attribs;

public class SupportedTravelCountry
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Country { get; set; }
}
