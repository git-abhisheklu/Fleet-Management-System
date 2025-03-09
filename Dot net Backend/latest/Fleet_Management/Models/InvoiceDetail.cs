using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Fleet_Management.Models;

[Table("invoice_details")]
[Index("AddonId", Name = "FK89xs1p3vm0kog77173n7iu45e")]
[Index("InvoiceId", Name = "FKs02xcl172h21utmbt7jko9iyg")]
public partial class InvoiceDetail
{
    [Key]
    [Column("invdtl_id")]
    public long InvdtlId { get; set; }

    [Column("add_on_amt")]
    public double AddOnAmt { get; set; }

    [Column("addon_id")]
    public long AddonId { get; set; }

    [Column("invoice_id")]
    public long InvoiceId { get; set; }

    [ForeignKey("AddonId")]
    [InverseProperty("InvoiceDetails")]
    public virtual AddOnMaster Addon { get; set; } = null!;

    [ForeignKey("InvoiceId")]
    [InverseProperty("InvoiceDetails")]
    public virtual InvoiceHeader Invoice { get; set; } = null!;
}
