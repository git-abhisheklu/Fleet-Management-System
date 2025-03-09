using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Fleet_Management.Models;

[Table("user_details")]
public partial class UserDetail
{
    [Key]
    [Column("userid")]
    public long Userid { get; set; }

    [Column("email")]
    [StringLength(255)]
    public string? Email { get; set; }

    [Column("last_name")]
    [StringLength(255)]
    public string? LastName { get; set; }

    [Column("password")]
    [StringLength(255)]
    public string? Password { get; set; }

    [Column("user_name")]
    [StringLength(255)]
    public string? UserName { get; set; }
}
