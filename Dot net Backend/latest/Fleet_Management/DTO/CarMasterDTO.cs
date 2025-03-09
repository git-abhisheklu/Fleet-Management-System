using System.Text.Json.Serialization;
using Fleet_Management.Models.DTO;

namespace Fleet_Management.Models.DTO
{
    public class CarMasterDTO
    {
        [JsonPropertyName("carId")]
        public long CarId { get; set; }

        [JsonPropertyName("carName")]
        public string? CarName { get; set; }

        [JsonPropertyName("numberPlate")]
        public string? NumberPlate { get; set; }

        [JsonPropertyName("fuelStatus")]
        public string? FuelStatus { get; set; }

        [JsonPropertyName("hub_id")]
        public HubDTO? Hub { get; set; }

        [JsonPropertyName("isAvailable")]
        public string? IsAvailable { get; set; }

        [JsonPropertyName("maintenanceduedate")]
        public DateOnly? MaintenanceDueDate { get; set; }

        [JsonPropertyName("carTypeId")]
        public CarTypeMasterDTO? CarType { get; set; }
    }
}
