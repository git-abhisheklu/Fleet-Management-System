using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Fleet_Management.Models;

[Table("add_on_master")]
public partial class AddOnMaster
{
    [Key]
    [Column("addon_id")]
    public long AddonId { get; set; }

    [Column("addon_daily_rate")]
    public double? AddonDailyRate { get; set; }

    [Column("addon_name")]
    [StringLength(255)]
    public string? AddonName { get; set; }

    [Column("rate_valid_upto")]
    public DateOnly? RateValidUpto { get; set; }

    [InverseProperty("Addon")]
    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();
}
