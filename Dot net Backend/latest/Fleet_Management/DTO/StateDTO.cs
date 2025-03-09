using System.Text.Json.Serialization;

public class StateDTO
{
    [JsonPropertyName("stateId")]
    public long StateId { get; set; }

    [JsonPropertyName("stateName")]
    public string? StateName { get; set; }
}
