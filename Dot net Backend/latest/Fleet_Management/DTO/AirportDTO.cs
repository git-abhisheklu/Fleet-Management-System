using System.Text.Json.Serialization;

public class AirportDTO
{
    [JsonPropertyName("airportId")]
    public long AirportId { get; set; }

    [JsonPropertyName("airportName")]
    public string? AirportName { get; set; }

    [JsonPropertyName("airportCode")]
    public string? AirportCode { get; set; }

    [JsonPropertyName("city")]
    public CityDTO? City { get; set; }

    [JsonPropertyName("state")]
    public StateDTO? State { get; set; }
}
