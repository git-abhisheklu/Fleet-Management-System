using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Fleet_Management.Models;

[Table("hub_master")]
[Index("CityId", Name = "FK7rdbu34jsqwuoyuound4e830p")]
[Index("AirportId", Name = "FK7u17hwotn2bo53jgudl1d4lqc")]
[Index("StateId", Name = "FKf94kvk79lamurkcyvj8hhop1q")]
[Index("ContactNumber", Name = "UKq4cka6kuf15mrgsvs05wj1e87", IsUnique = true)]
public partial class HubMaster
{
    [Key]
    [Column("hub_id")]
    public long HubId { get; set; }

    [Column("contact_number")]
    public long? ContactNumber { get; set; }

    [Column("hub_address")]
    [StringLength(255)]
    public string? HubAddress { get; set; }

    [Column("hub_name")]
    [StringLength(255)]
    public string? HubName { get; set; }

    [Column("airport_id")]
    public long AirportId { get; set; }

    [Column("city_id")]
    public long CityId { get; set; }

    [Column("state_id")]
    public long StateId { get; set; }

    [ForeignKey("AirportId")]
    [InverseProperty("HubMasters")]
    public virtual AirportMaster Airport { get; set; } = null!;

    [InverseProperty("Hub")]
    public virtual ICollection<CarMaster> CarMasters { get; set; } = new List<CarMaster>();

    [ForeignKey("CityId")]
    [InverseProperty("HubMasters")]
    public virtual CityMaster City { get; set; } = null!;

    [ForeignKey("StateId")]
    [InverseProperty("HubMasters")]
    public virtual StateMaster State { get; set; } = null!;
}
