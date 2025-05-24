namespace Ava.Shared.Models.Kernel.Client.Attribs;

public class SupportedCountry
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Country { get; set; }
}
