using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Fleet_Management.Models;

[Table("booking")]
[Index("CarId", Name = "FKlx0rl5snxubqb9tqowsei8pui")]
[Index("CartypeId", Name = "FKqurxnyq5tvwoi3smjjvvdrpmm")]
[Index("CustomerId", Name = "FKtoarwuiok8h6fhdse2fylg7bk")]
public partial class Booking
{
    [Key]
    [Column("booking_id")]
    public long BookingId { get; set; }

    [Column("address")]
    [StringLength(255)]
    public string Address { get; set; } = null!;

    [Column("bookingdate")]
    public DateOnly Bookingdate { get; set; }

    [Column("dailyrate")]
    public double? Dailyrate { get; set; }

    [Column("email_id")]
    [StringLength(255)]
    public string EmailId { get; set; } = null!;

    [Column("enddate")]
    public DateOnly Enddate { get; set; }

    [Column("firstname")]
    [StringLength(255)]
    public string Firstname { get; set; } = null!;

    [Column("lastname")]
    [StringLength(255)]
    public string Lastname { get; set; } = null!;

    [Column("monthlyrate")]
    public double? Monthlyrate { get; set; }

    [Column("pickup_hub_id")]
    public int PickupHubId { get; set; }

    [Column("pin")]
    [StringLength(255)]
    public string Pin { get; set; } = null!;

    [Column("return_hub_id")]
    public int ReturnHubId { get; set; }

    [Column("startdate")]
    public DateOnly Startdate { get; set; }

    [Column("state")]
    [StringLength(255)]
    public string State { get; set; } = null!;

    [Column("weeklyrate")]
    public double? Weeklyrate { get; set; }

    [Column("car_id")]
    public long CarId { get; set; }

    [Column("cartype_id")]
    public long CartypeId { get; set; }

    [Column("customer_id")]
    public long? CustomerId { get; set; }

    [Column("pickup_hub_address")]
    [StringLength(255)]
    public string? PickupHubAddress { get; set; }

    [Column("return_hub_address")]
    [StringLength(255)]
    public string? ReturnHubAddress { get; set; }

    [InverseProperty("Booking")]
    public virtual ICollection<BookingDetail> BookingDetails { get; set; } = new List<BookingDetail>();

    [ForeignKey("CarId")]
    [InverseProperty("Bookings")]
    public virtual CarMaster Car { get; set; } = null!;

    [ForeignKey("CartypeId")]
    [InverseProperty("Bookings")]
    public virtual CarTypeMaster Cartype { get; set; } = null!;

    [ForeignKey("CustomerId")]
    [InverseProperty("Bookings")]
    public virtual CustomerMaster? Customer { get; set; }

    [InverseProperty("Booking")]
    public virtual ICollection<InvoiceHeader> InvoiceHeaders { get; set; } = new List<InvoiceHeader>();
}
