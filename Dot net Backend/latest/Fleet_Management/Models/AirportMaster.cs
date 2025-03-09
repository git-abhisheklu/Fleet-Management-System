using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Fleet_Management.Models;

[Table("airport_master")]
[Index("StateId", Name = "FKgykh73g2t7b9tyhou2eve5ljf")]
[Index("CityId", Name = "FKnacm5228qoxi0egygij94kqje")]
[Index("AirportCode", Name = "UKru44fgkyk5t6n71fm3gi062mw", IsUnique = true)]
public partial class AirportMaster
{
    [Key]
    [Column("airport_id")]
    public long AirportId { get; set; }

    [Column("airport_code")]
    public string? AirportCode { get; set; }

    [Column("airport_name")]
    [StringLength(255)]
    public string? AirportName { get; set; }

    [Column("city_id")]
    public long CityId { get; set; }

    [Column("state_id")]
    public long StateId { get; set; }

    [ForeignKey("CityId")]
    [InverseProperty("AirportMasters")]
    public virtual CityMaster City { get; set; } = null!;

    [InverseProperty("Airport")]
    public virtual ICollection<HubMaster> HubMasters { get; set; } = new List<HubMaster>();

    [ForeignKey("StateId")]
    [InverseProperty("AirportMasters")]
    public virtual StateMaster State { get; set; } = null!;
}
