using System;
using System.Collections.Generic;
using Fleet_Management.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Fleet_Management.Repository;

public partial class FleetDbContext : DbContext
{
    public FleetDbContext()
    {
    }

    public FleetDbContext(DbContextOptions<FleetDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AddOnMaster> AddOnMasters { get; set; }

    public virtual DbSet<AirportMaster> AirportMasters { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<BookingDetail> BookingDetails { get; set; }

    public virtual DbSet<CarMaster> CarMasters { get; set; }

    public virtual DbSet<CarTypeMaster> CarTypeMasters { get; set; }

    public virtual DbSet<CityMaster> CityMasters { get; set; }

    public virtual DbSet<CustomerMaster> CustomerMasters { get; set; }

    public virtual DbSet<HubMaster> HubMasters { get; set; }

    public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }

    public virtual DbSet<InvoiceHeader> InvoiceHeaders { get; set; }

    public virtual DbSet<Membership> Memberships { get; set; }

    public virtual DbSet<StateMaster> StateMasters { get; set; }

    public virtual DbSet<UserDetail> UserDetails { get; set; }

    public virtual DbSet<UserLogin> UserLogins { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost;database=fleettest1;user=root;password=rajiv2002", Microsoft.EntityFrameworkCore.ServerVersion.Parse("9.0.1-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<AddOnMaster>(entity =>
        {
            entity.HasKey(e => e.AddonId).HasName("PRIMARY");
        });

        modelBuilder.Entity<AirportMaster>(entity =>
        {
            entity.HasKey(e => e.AirportId).HasName("PRIMARY");

            entity.HasOne(d => d.City).WithMany(p => p.AirportMasters)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKnacm5228qoxi0egygij94kqje");

            entity.HasOne(d => d.State).WithMany(p => p.AirportMasters)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKgykh73g2t7b9tyhou2eve5ljf");
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PRIMARY");

            entity.HasOne(d => d.Car).WithMany(p => p.Bookings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKlx0rl5snxubqb9tqowsei8pui");

            entity.HasOne(d => d.Cartype).WithMany(p => p.Bookings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKqurxnyq5tvwoi3smjjvvdrpmm");

            entity.HasOne(d => d.Customer).WithMany(p => p.Bookings).HasConstraintName("FKtoarwuiok8h6fhdse2fylg7bk");
        });

        modelBuilder.Entity<BookingDetail>(entity =>
        {
            entity.HasKey(e => e.BookingDetailId).HasName("PRIMARY");

            entity.HasOne(d => d.Booking).WithMany(p => p.BookingDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK59941ondg9nwaifm2umnrduev");
        });

        modelBuilder.Entity<CarMaster>(entity =>
        {
            entity.HasKey(e => e.CarId).HasName("PRIMARY");

            entity.HasOne(d => d.Cartype).WithMany(p => p.CarMasters)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKe7t3ybbd5mnrqomrch1wuyc6m");

            entity.HasOne(d => d.Hub).WithMany(p => p.CarMasters)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKrbd83493vx6lu3vprvkx8qgqh");
        });

        modelBuilder.Entity<CarTypeMaster>(entity =>
        {
            entity.HasKey(e => e.CartypeId).HasName("PRIMARY");
        });

        modelBuilder.Entity<CityMaster>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PRIMARY");

            entity.HasOne(d => d.State).WithMany(p => p.CityMasters)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKfxtjuwt9iqx9n7xl6f8wl6uu4");
        });

        modelBuilder.Entity<CustomerMaster>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PRIMARY");
        });

        modelBuilder.Entity<HubMaster>(entity =>
        {
            entity.HasKey(e => e.HubId).HasName("PRIMARY");

            entity.HasOne(d => d.Airport).WithMany(p => p.HubMasters)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK7u17hwotn2bo53jgudl1d4lqc");

            entity.HasOne(d => d.City).WithMany(p => p.HubMasters)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK7rdbu34jsqwuoyuound4e830p");

            entity.HasOne(d => d.State).WithMany(p => p.HubMasters)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKf94kvk79lamurkcyvj8hhop1q");
        });

        modelBuilder.Entity<InvoiceDetail>(entity =>
        {
            entity.HasKey(e => e.InvdtlId).HasName("PRIMARY");

            entity.HasOne(d => d.Addon).WithMany(p => p.InvoiceDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK89xs1p3vm0kog77173n7iu45e");

            entity.HasOne(d => d.Invoice).WithMany(p => p.InvoiceDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKs02xcl172h21utmbt7jko9iyg");
        });

        modelBuilder.Entity<InvoiceHeader>(entity =>
        {
            entity.HasKey(e => e.InvoiceId).HasName("PRIMARY");

            entity.HasOne(d => d.Booking).WithMany(p => p.InvoiceHeaders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK1rk1jp3v1teuk31m3jpg4ug2i");

            entity.HasOne(d => d.Car).WithMany(p => p.InvoiceHeaders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKd2t74dthekdhhrfb3pottooy4");

            entity.HasOne(d => d.Customer).WithMany(p => p.InvoiceHeaders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKhky9vtepslur0k09ifs19qkp3");
        });

        modelBuilder.Entity<Membership>(entity =>
        {
            entity.HasKey(e => e.MembershipId).HasName("PRIMARY");

            entity.HasOne(d => d.Customer).WithMany(p => p.Memberships)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKgcg2nvwntsu1wkyo1qc8k9cu1");
        });

        modelBuilder.Entity<StateMaster>(entity =>
        {
            entity.HasKey(e => e.StateId).HasName("PRIMARY");
        });

        modelBuilder.Entity<UserDetail>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("PRIMARY");
        });

        modelBuilder.Entity<UserLogin>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("PRIMARY");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
