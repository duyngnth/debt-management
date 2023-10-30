using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DebtManagement.Models;

public partial class DebtManagementContext : DbContext
{
    public DebtManagementContext()
    {
    }

    public DebtManagementContext(DbContextOptions<DebtManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Debit> Debits { get; set; }

    public virtual DbSet<DebitDetail> DebitDetails { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Debit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Debit__3213E83F20A988B4");

            entity.ToTable("Debit");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreditorId).HasColumnName("creditorId");
            entity.Property(e => e.DebtorName)
                .HasMaxLength(50)
                .HasColumnName("debtorName");
            entity.Property(e => e.DebtorPhone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("debtorPhone");
            entity.Property(e => e.Description).HasColumnName("description");

            entity.HasOne(d => d.Creditor).WithMany(p => p.Debits)
                .HasForeignKey(d => d.CreditorId)
                .HasConstraintName("FK__Debit__creditorI__398D8EEE");

            entity.HasMany(p => p.DebitDetails).WithOne(p => p.Debit)
                .HasForeignKey(d => d.DebitId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<DebitDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DebitDet__3213E83F9CF2FF82");

            entity.ToTable("DebitDetail");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasColumnType("money")
                .HasColumnName("amount");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.Deadline)
                .HasColumnType("datetime")
                .HasColumnName("deadline");
            entity.Property(e => e.DebitId).HasColumnName("debitId");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IsPaid).HasColumnName("isPaid");

            entity.HasOne(d => d.Debit).WithMany(p => p.DebitDetails)
                .HasForeignKey(d => d.DebitId)
                .HasConstraintName("FK__DebitDeta__debit__3C69FB99")
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3213E83F96D34D0A");

            entity.ToTable("User");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(50)
                .HasColumnName("displayName");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
