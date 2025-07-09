namespace Ava.Shared.Models.DTOs;
public class TravelPolicyBookingContextDTO
{
    [MaxLength(14)]
    public required string Id { get; set; }
    public required string PolicyName { get; set; }
    public int AvaClientId { get; set; }
    public string AvaClientName { get; set; } = string.Empty;

    [Required]
    [RegularExpression(@"^[A-Z]{3}$", ErrorMessage = "Currency must be exactly 3 uppercase letters.")]
    [JsonPropertyName("currency")]
    [DefaultValue("AUD")]
    public required string Currency { get; set; } = "AUD";
    public int? MaxFlightPrice { get; set; }
    public required string DefaultFlightSeating { get; set; } = "ECONOMY";
    public required string MaxFlightSeating { get; set; } = "ECONOMY";
    public required string CabinClassCoverage { get; set; } = "MOST_SEGMENTS";
    public bool NonStopFlight { get; set; } = false;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [RegularExpression(@"^(0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "Time must be in the format hh:mm.")]
    public string? FlightBookingTimeAvailableFrom { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [RegularExpression(@"^(0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "Time must be in the format hh:mm.")]
    public string? FlightBookingTimeAvailableTo { get; set; }
    public bool EnableSaturdayFlightBookings { get; set; } = false;
    public bool EnableSundayFlightBookings { get; set; } = false;
    public int? DefaultCalendarDaysInAdvanceForFlightBooking { get; set; }
    public string? IncludedAirlineCodes { get; set; }
    public string? ExcludedAirlineCodes { get; set; }
    public List<string>? Regions { get; set; }
    public List<string>? Continents { get; set; }
    public List<string>? Countries { get; set; }
    public List<string>? DisabledCountries { get; set; }

    // [meta]
    public int MaxResults { get; set; } = 20;
}

