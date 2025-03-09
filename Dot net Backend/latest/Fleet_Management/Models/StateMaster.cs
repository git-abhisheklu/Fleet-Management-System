using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Fleet_Management.Models;

[Table("state_master")]
[Index("StateName", Name = "UKm5af6dlen3aq3mvubt194s0j6", IsUnique = true)]
public partial class StateMaster
{
    [Key]
    [Column("state_id")]
    [JsonPropertyName("stateId")]  
    public long StateId { get; set; }

    [Column("state_name")]
    [JsonPropertyName("stateName")]    
    public string? StateName { get; set; }

    [InverseProperty("State")]
    [JsonIgnore]
    public virtual ICollection<AirportMaster> AirportMasters { get; set; } = new List<AirportMaster>();

    [InverseProperty("State")]
    [JsonIgnore]
    public virtual ICollection<CityMaster> CityMasters { get; set; } = new List<CityMaster>();

    [InverseProperty("State")]
    [JsonIgnore]
    public virtual ICollection<HubMaster> HubMasters { get; set; } = new List<HubMaster>();
}
