using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Reservation_Managmeent_App.Models;

namespace Reservation_Managmeent_App.Data;

public partial class ReservationDbContext : DbContext
{
    public ReservationDbContext()
    {
    }

    public ReservationDbContext(DbContextOptions<ReservationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<ReservationDoc> ReservationDocs { get; set; }

    public virtual DbSet<ReservationType> ReservationTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=Reservations_DB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reservat__3213E83F18ABF896");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.ConfirmationId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("confirmation_id");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_on");
            entity.Property(e => e.Remarks)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("remarks");
            entity.Property(e => e.ReservationDate).HasColumnName("reservation_date");
            entity.Property(e => e.ReservationDoneByEmployeeId).HasColumnName("reservation_done_by_employee_id");
            entity.Property(e => e.ReservationDoneWithEntity)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("reservation_done_with_entity");
            entity.Property(e => e.ReservationTypeId).HasColumnName("reservation_type_id");
            entity.Property(e => e.TravelRequestId).HasColumnName("travel_request_id");

            entity.HasOne(d => d.ReservationType).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.ReservationTypeId)
                .HasConstraintName("FK__Reservati__reser__4CA06362");
        });

        modelBuilder.Entity<ReservationDoc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reservat__3213E83F0E0CCB84");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DocumentUrl)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("document_url");
            entity.Property(e => e.ReservationId).HasColumnName("reservation_id");

            entity.HasOne(d => d.Reservation).WithMany(p => p.ReservationDocs)
                .HasForeignKey(d => d.ReservationId)
                .HasConstraintName("FK__Reservati__reser__5165187F");
        });

        modelBuilder.Entity<ReservationType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PK__Reservat__2C0005988FDA1CBD");

            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.TypeName)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("type_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
