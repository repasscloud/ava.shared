namespace Ava.Shared.Models.Kernel.Client.Attribs;

public class SupportedTravelRegion
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Region { get; set; }
}
