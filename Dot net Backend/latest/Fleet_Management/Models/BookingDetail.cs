using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Fleet_Management.Models;

[Table("booking_detail")]
[Index("BookingId", Name = "FK59941ondg9nwaifm2umnrduev")]
public partial class BookingDetail
{
    [Key]
    [Column("booking_detail_id")]
    public long BookingDetailId { get; set; }

    [Column("addon_id")]
    public long? AddonId { get; set; }

    [Column("addon_rate")]
    public double? AddonRate { get; set; }

    [Column("booking_id")]
    public long BookingId { get; set; }

    [ForeignKey("BookingId")]
    [InverseProperty("BookingDetails")]
    public virtual Booking Booking { get; set; } = null!;
}
