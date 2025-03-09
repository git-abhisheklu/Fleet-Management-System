using System.Text.Json.Serialization;

public class CityDTO
{
    [JsonPropertyName("cityId")]
    public long CityId { get; set; }

    [JsonPropertyName("cityName")]
    public string? CityName { get; set; }

    [JsonPropertyName("state")]
    public StateDTO? State { get; set; }
}
