using System.Text.Json.Serialization;

public class HubDTO
{
    [JsonPropertyName("hubId")]
    public long HubId { get; set; }

    [JsonPropertyName("contactNumber")]
    public long? ContactNumber { get; set; }

    [JsonPropertyName("hubAddress")]
    public string? HubAddress { get; set; }

    [JsonPropertyName("hubName")]
    public string? HubName { get; set; }

    [JsonPropertyName("airport")]
    public AirportDTO? Airport { get; set; }

    [JsonPropertyName("city")]
    public CityDTO? City { get; set; }

    [JsonPropertyName("state")]
    public StateDTO? State { get; set; }
}
