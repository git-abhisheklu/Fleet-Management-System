using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Fleet_Management.Models;

[Table("membership")]
[Index("CustomerId", Name = "FKgcg2nvwntsu1wkyo1qc8k9cu1")]
public partial class Membership
{
    [Key]
    [Column("membership_id")]
    public long MembershipId { get; set; }

    [Column("end_date")]
    public DateOnly? EndDate { get; set; }

    [Column("fee")]
    public double? Fee { get; set; }

    [Column("membership_type")]
    [StringLength(255)]
    public string? MembershipType { get; set; }

    [Column("start_date")]
    public DateOnly? StartDate { get; set; }

    [Column("customer_id")]
    public long CustomerId { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("Memberships")]
    public virtual CustomerMaster Customer { get; set; } = null!;
}
