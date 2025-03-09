using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Fleet_Management.Models;

[Table("car_type_master")]
public partial class CarTypeMaster
{
    [Key]
    [Column("cartype_id")]
    public long CartypeId { get; set; }

    [Column("car_type_name")]
    [StringLength(255)]
    public string? CarTypeName { get; set; }

    [Column("daily_rate")]
    public double? DailyRate { get; set; }

    [Column("image_path")]
    [StringLength(255)]
    public string? ImagePath { get; set; }

    [Column("monthly_rate")]
    public double? MonthlyRate { get; set; }

    [Column("weekly_rate")]
    public double? WeeklyRate { get; set; }

    [InverseProperty("Cartype")]
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    [InverseProperty("Cartype")]
    public virtual ICollection<CarMaster> CarMasters { get; set; } = new List<CarMaster>();
}
