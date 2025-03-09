using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Fleet_Management.Models;

[Table("car_master")]
[Index("CartypeId", Name = "FKe7t3ybbd5mnrqomrch1wuyc6m")]
[Index("HubId", Name = "FKrbd83493vx6lu3vprvkx8qgqh")]
[Index("NumberPlate", Name = "UKonp0df5km5sg4h2s4w34uc0yn", IsUnique = true)]
public partial class CarMaster
{
    [Key]
    [Column("car_id")]
    public long CarId { get; set; }

    [Column("car_name")]
    [StringLength(255)]
    public string? CarName { get; set; }

    [Column("fuel_status")]
    [StringLength(255)]
    public string? FuelStatus { get; set; }

    [Column("is_available", TypeName = "enum('N','Y')")]
    public string? IsAvailable { get; set; }

    [Column("maintenanceduedate")]
    public DateOnly? Maintenanceduedate { get; set; }

    [Column("mileage")]
    public double? Mileage { get; set; }

    [Column("number_plate")]
    public string? NumberPlate { get; set; }

    [Column("cartype_id")]
    public long CartypeId { get; set; }

    [Column("hub_id")]
    public long HubId { get; set; }

    [InverseProperty("Car")]
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    [ForeignKey("CartypeId")]
    [InverseProperty("CarMasters")]
    public virtual CarTypeMaster Cartype { get; set; } = null!;

    [ForeignKey("HubId")]
    [InverseProperty("CarMasters")]
    public virtual HubMaster Hub { get; set; } = null!;

    [InverseProperty("Car")]
    public virtual ICollection<InvoiceHeader> InvoiceHeaders { get; set; } = new List<InvoiceHeader>();
}
