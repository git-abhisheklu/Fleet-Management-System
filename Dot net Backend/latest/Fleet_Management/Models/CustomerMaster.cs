using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Fleet_Management.Models;

[Table("customer_master")]
[Index("Email", Name = "UKsnf65l86t4b0xj6v0f9nymegs", IsUnique = true)]
public partial class CustomerMaster
{
    [Key]
    [Column("customer_id")]
    public long CustomerId { get; set; }

    [Column("address_line1")]
    [StringLength(255)]
    public string? AddressLine1 { get; set; }

    [Column("address_line2")]
    [StringLength(255)]
    public string? AddressLine2 { get; set; }

    [Column("city")]
    [StringLength(255)]
    public string? City { get; set; }

    [Column("credit_card_number")]
    [StringLength(255)]
    public string? CreditCardNumber { get; set; }

    [Column("credit_card_type")]
    [StringLength(255)]
    public string? CreditCardType { get; set; }

    [Column("date_of_birth")]
    public DateOnly? DateOfBirth { get; set; }

    [Column("driving_license_number")]
    [StringLength(255)]
    public string? DrivingLicenseNumber { get; set; }

    [Column("email")]
    public string? Email { get; set; }

    [Column("first_name")]
    [StringLength(255)]
    public string? FirstName { get; set; }

    [Column("idp_number")]
    [StringLength(255)]
    public string? IdpNumber { get; set; }

    [Column("issued_bydl")]
    [StringLength(255)]
    public string? IssuedBydl { get; set; }

    [Column("last_name")]
    [StringLength(255)]
    public string? LastName { get; set; }

    [Column("mobile_number")]
    [StringLength(255)]
    public string? MobileNumber { get; set; }

    [Column("passport_issue_date")]
    public DateOnly? PassportIssueDate { get; set; }

    [Column("passport_issued_by")]
    [StringLength(255)]
    public string? PassportIssuedBy { get; set; }

    [Column("passport_number")]
    [StringLength(255)]
    public string? PassportNumber { get; set; }

    [Column("passport_valid_from")]
    public DateOnly? PassportValidFrom { get; set; }

    [Column("passport_valid_through")]
    public DateOnly? PassportValidThrough { get; set; }

    [Column("phone_number")]
    [StringLength(255)]
    public string? PhoneNumber { get; set; }

    [Column("pincode")]
    [StringLength(255)]
    public string? Pincode { get; set; }

    [Column("valid_throughdl")]
    public DateOnly? ValidThroughdl { get; set; }

    [InverseProperty("Customer")]
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    [InverseProperty("Customer")]
    public virtual ICollection<InvoiceHeader> InvoiceHeaders { get; set; } = new List<InvoiceHeader>();

    [InverseProperty("Customer")]
    public virtual ICollection<Membership> Memberships { get; set; } = new List<Membership>();
}
