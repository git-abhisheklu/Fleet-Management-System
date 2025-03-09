using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Fleet_Management.Models;

[Table("city_master")]
[Index("StateId", Name = "FKfxtjuwt9iqx9n7xl6f8wl6uu4")]
public partial class CityMaster
{
    [Key]
    [Column("city_id")]
    [JsonPropertyName("city_id")]
    public long CityId { get; set; }

    [Column("city_name")]
    [StringLength(255)]
    [JsonPropertyName("city_name")]
    public string? CityName { get; set; }

    [Column("state_id")]
    [JsonPropertyName("state_id")]
    public long StateId { get; set; }

    [InverseProperty("City")]
    public virtual ICollection<AirportMaster> AirportMasters { get; set; } = new List<AirportMaster>();

    [InverseProperty("City")]
    [JsonIgnore]
    public virtual ICollection<HubMaster> HubMasters { get; set; } = new List<HubMaster>();

    [ForeignKey("StateId")]
    [InverseProperty("CityMasters")]
    public virtual StateMaster State { get; set; } = null!;
}
