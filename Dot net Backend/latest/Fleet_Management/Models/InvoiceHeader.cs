using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Fleet_Management.Models;

[Table("invoice_header")]
[Index("BookingId", Name = "FK1rk1jp3v1teuk31m3jpg4ug2i")]
[Index("CarId", Name = "FKd2t74dthekdhhrfb3pottooy4")]
[Index("CustomerId", Name = "FKhky9vtepslur0k09ifs19qkp3")]
public partial class InvoiceHeader
{
    [Key]
    [Column("invoice_id")]
    public long InvoiceId { get; set; }

    [Column("c_aadhar_no")]
    [StringLength(255)]
    public string? CAadharNo { get; set; }

    [Column("c_email_id")]
    [StringLength(255)]
    public string? CEmailId { get; set; }

    [Column("c_mobile_no")]
    [StringLength(255)]
    public string? CMobileNo { get; set; }

    [Column("c_name")]
    [StringLength(255)]
    public string? CName { get; set; }

    [Column("c_pass_no")]
    [StringLength(255)]
    public string? CPassNo { get; set; }

    [Column("handover_date")]
    public DateOnly? HandoverDate { get; set; }

    [Column("is_returned", TypeName = "enum('N','Y')")]
    public string? IsReturned { get; set; }

    [Column("pickup_hub_id")]
    public long? PickupHubId { get; set; }

    [Column("rate")]
    [StringLength(255)]
    public string? Rate { get; set; }

    [Column("rental_amt")]
    public double RentalAmt { get; set; }

    [Column("return_date")]
    public DateOnly? ReturnDate { get; set; }

    [Column("return_hub_id")]
    public long? ReturnHubId { get; set; }

    [Column("total_add_on_amt")]
    public double TotalAddOnAmt { get; set; }

    [Column("total_amt")]
    public double TotalAmt { get; set; }

    [Column("booking_id")]
    public long BookingId { get; set; }

    [Column("car_id")]
    public long CarId { get; set; }

    [Column("customer_id")]
    public long CustomerId { get; set; }

    [ForeignKey("BookingId")]
    [InverseProperty("InvoiceHeaders")]
    public virtual Booking Booking { get; set; } = null!;

    [ForeignKey("CarId")]
    [InverseProperty("InvoiceHeaders")]
    public virtual CarMaster Car { get; set; } = null!;

    [ForeignKey("CustomerId")]
    [InverseProperty("InvoiceHeaders")]
    public virtual CustomerMaster Customer { get; set; } = null!;

    [InverseProperty("Invoice")]
    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();
}
