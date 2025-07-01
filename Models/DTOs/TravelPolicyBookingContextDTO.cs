namespace Ava.Shared.Models.DTOs;

public class TravelPolicyBookingContextDTO
{
    public string? Id { get; set; }
    public string? PolicyName { get; set; }
    public string? AvaClientName { get; set; }
    public string? Currency { get; set; }
    public int? MaxFlightPrice { get; set; }
    public string? DefaultFlightSeating { get; set; }
    public string? MaxFlightSeating { get; set; }
    public string? CabinClassCoverage { get; set; }
    public bool NonStopFlight { get; set; } = false;
    public string? FlightBookingTimeAvailableFrom { get; set; }
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
}

