using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Fleet_Management.Models;

[Table("user_login")]
public partial class UserLogin
{
    [Key]
    [Column("userid")]
    public long Userid { get; set; }

    [Column("email")]
    [StringLength(255)]
    public string? Email { get; set; }

    [Column("first_name")]
    [StringLength(255)]
    public string? FirstName { get; set; }

    [Column("last_name")]
    [StringLength(255)]
    public string? LastName { get; set; }

    [Column("password")]
    [StringLength(255)]
    public string? Password { get; set; }

    [Column("role")]
    [StringLength(255)]
    public string? Role { get; set; }

    [Column("user_name")]
    [StringLength(255)]
    public string? UserName { get; set; }
}
