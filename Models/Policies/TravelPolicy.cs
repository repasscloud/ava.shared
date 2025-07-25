namespace Ava.Shared.Models.Policies;

public class TravelPolicy
{
    [Key]
    [MaxLength(14)]
    public required string Id { get; set; }
    public required string PolicyName { get; set; }
    public int AvaClientId { get; set; }

    // financial details
    [Required]
    [CurrencyTypeValidation]
    [RegularExpression(@"^[A-Z]{3}$", ErrorMessage = "Currency must be exactly 3 uppercase letters.")]
    [JsonPropertyName("currency")]
    [DefaultValue("AUD")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public required string DefaultCurrencyCode { get; set; } = "AUD";

    public int MaxFlightPrice { get; set; } = 0;

    // flight particulars
    [CabinTypeValidation]
    [DefaultValue("ECONOMY")]
    public string DefaultFlightSeating { get; set; } = "ECONOMY";

    [CabinTypeValidation]
    [DefaultValue("ECONOMY")]
    public string MaxFlightSeating { get; set; } = "ECONOMY";

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? IncludedAirlineCodes { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ExcludedAirlineCodes { get; set; }

    [CoverageTypeValidation]
    [DefaultValue("MOST_SEGMENTS")]
    public string CabinClassCoverage { get; set; } = "MOST_SEGMENTS";
    public bool NonStopFlight { get; set; } = false;

    // amadeus (and other system) specifics [meta]
    //public int MaxResults { get; set; } = 20;

    // times for bookings (business rules)
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [RegularExpression(@"^(0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "Time must be in the format hh:mm.")]
    public string? FlightBookingTimeAvailableFrom { get; set; }  // Local time. hh:mm format, e.g 10:30

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [RegularExpression(@"^(0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "Time must be in the format hh:mm.")]
    public string? FlightBookingTimeAvailableTo { get; set; }  // Local time. hh:mm format, e.g 10:30

    [DefaultValue(false)]
    public bool EnableSaturdayFlightBookings { get; set; } = false;

    [DefaultValue(false)]
    public bool EnableSundayFlightBookings { get; set; } = false;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? DefaultCalendarDaysInAdvanceForFlightBooking { get; set; }

    [JsonIgnore] // Prevent circular reference during serialization.
    public AvaClient? AvaClient { get; set; }

    // Allowed destinations (can be entire regions, continents, or specific countries)
    public ICollection<Region> Regions { get; set; } = new List<Region>();
    public ICollection<Continent> Continents { get; set; } = new List<Continent>();
    public ICollection<Country> Countries { get; set; } = new List<Country>();

    // If a broader selection is made (e.g. enabling APAC),
    // you can exclude specific countries via this collection.
    public ICollection<TravelPolicyDisabledCountry> DisabledCountries { get; set; } = new List<TravelPolicyDisabledCountry>();

    // allowed returned results (default 20)
    public int MaxResults { get; set; } = 20;
}
