namespace Ava.Shared.Services;

public class AvaApiService : IAvaApiService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AvaApiService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<TResponse?> PostAsync<TRequest, TResponse>(string endpoint, TRequest request, string avaToken)
    {
        var client = _httpClientFactory.CreateClient("AvaAPI"); // Use registered client
        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        // Add custom header
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", avaToken);

        var response = await client.PostAsync(endpoint, content);

        if (!response.IsSuccessStatusCode)
        {
            return default;
        }

        var responseJson = await response.Content.ReadAsStringAsync();

        // Handle plain string responses correctly
        if (typeof(TResponse) == typeof(string))
        {
            return (TResponse)(object)responseJson;
        }

        return JsonSerializer.Deserialize<TResponse>(responseJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }

    public async Task<TravelSearchRecordWrapper> PostFlightSearchQueryAsync(FlightOfferSearchRequestDTO criteria, string bearerToken)
    {
        var client = _httpClientFactory.CreateClient("AvaAPI");
        var json = JsonSerializer.Serialize(criteria);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        // add custom headers
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

        string endpoint = "/api/v1/flights/search";

        var response = await client.PostAsync(endpoint, content);
        
        if (!response.IsSuccessStatusCode)
        {
            string errorMessage = $"API Error {response.StatusCode}: {response}";
    
            return new TravelSearchRecordWrapper
            {
                TravelSearchRecord = string.Empty,
            };
        }
        
        var responseJson = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<TravelSearchRecordWrapper>(responseJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
            ?? throw new JsonException("Deserialization returned null for TravelSearchRecordWrapper.");
    }

    public async Task<AvaClientSupportedDomain> GetClientIdAsync(EmailDTO criteria, string bearerToken)
    {
        var client = _httpClientFactory.CreateClient("AvaAPI");
        var json = JsonSerializer.Serialize(criteria);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        // add custom headers
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

        string endpoint = "/api/ClientSupportedDomains/email";

        var response = await client.PostAsync(endpoint, content);
        
        if (!response.IsSuccessStatusCode)
        {
            string errorMessage = $"API Error {response.StatusCode}: {response}";
    
            return new AvaClientSupportedDomain { Id = 0, AvaClientId = 0, SupportedEmailDomain = "NULL" };
        }
        
        var responseJson = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<AvaClientSupportedDomain>(responseJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
            ?? throw new JsonException("Deserialization returned null for AvaClientSupportedDomain.");
    }

    public async Task<TravelPolicy> GetTravelPolicyByIdAsync(string travelPolicyId, string bearerToken)
    {
        var client = _httpClientFactory.CreateClient("AvaAPI");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

        string endpoint = $"api/TravelPolicy/{travelPolicyId}";
        var response = await client.GetAsync(endpoint);
        
        if (!response.IsSuccessStatusCode)
        {
            // Optionally, you could throw an exception or return a default value
            throw new Exception($"API Error {response.StatusCode}: {await response.Content.ReadAsStringAsync()}");
        }

        var responseJson = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<TravelPolicy>(responseJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
            ?? throw new JsonException("Deserialization returned null for TravelPolicy.");
    }

    public async Task<TravelPolicyBookingContextDTO> GetTravelPolicyInterResultByIdAsync(string travelPolicyId, string bearerToken)
    {
        var client = _httpClientFactory.CreateClient("AvaAPI");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

        string endpoint = $"api/v1/policies/travel/{travelPolicyId}";
        var response = await client.GetAsync(endpoint);
        
        if (!response.IsSuccessStatusCode)
        {
            // Optionally, you could throw an exception or return a default value
            throw new Exception($"API Error {response.StatusCode}: {await response.Content.ReadAsStringAsync()}");
        }

        var responseJson = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<TravelPolicyBookingContextDTO>(responseJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
            ?? throw new JsonException("Deserialization returned null for TravelPolicyBookingContextDTO.");
    }

    public async Task<AvaUserSysPreference> GetAvaUserSysPreferencesAsync(string aspNetUsersId, string bearerToken)
    {
        var client = _httpClientFactory.CreateClient("AvaAPI");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

        string endpoint = $"api/AvaUser/userpref/{aspNetUsersId}";
        var response = await client.GetAsync(endpoint);

        if (!response.IsSuccessStatusCode)
        {
            // Optionally, you could throw an exception or return a default value
            throw new Exception($"API Error {response.StatusCode}: {await response.Content.ReadAsStringAsync()}");
        }

        var responseJson = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<AvaUserSysPreference>(responseJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
            ?? throw new JsonException("Deserialization returned null for AvaUserSysPreference.");
    }
}
