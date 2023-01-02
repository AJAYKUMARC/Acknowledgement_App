using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Acknowledgement_App.Models;

public partial class DbAckContext : DbContext
{
    public DbAckContext()
    {
    }

    public DbAckContext(DbContextOptions<DbAckContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ack> Acks { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("Server=.;Database=dbAck;Trusted_Connection=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ack>(entity =>
        {
            entity.ToTable("Ack");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("amount");
            entity.Property(e => e.ApplicationFor)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("application_for");
            entity.Property(e => e.AppliedOn)
                .HasColumnType("datetime")
                .HasColumnName("applied_on");
            entity.Property(e => e.ChallanNo)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("challan_no");
            entity.Property(e => e.DateOfIssue)
                .HasColumnType("datetime")
                .HasColumnName("date_of_issue");
            entity.Property(e => e.HallticketNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("hallticket_no");
            entity.Property(e => e.NoOfCertificates).HasColumnName("no_of_certificates");
            entity.Property(e => e.Remark)
                .HasColumnType("text")
                .HasColumnName("remark");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
