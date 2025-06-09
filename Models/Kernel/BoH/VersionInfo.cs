namespace Ava.Shared.Models.Kernel.BoH;

public class VersionInfo
{
    [Key]
    public int Id { get; set; }

    [Required]
    [EnvironmentTypeValidation]
    public required string Env { get; set; }

    public string? ClientVersion { get; set; }
    public string? ApiVersion { get; set; }
    public string? WebAppVersion { get; set; }

    public DateTime? Updated { get; set; }

    public VersionInfo()
    {
        Updated = DateTime.UtcNow;
    }
}
