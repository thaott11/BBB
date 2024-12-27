using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Demo_Dapper.Models;

public partial class InsertDataContext : DbContext
{
    public InsertDataContext()
    {
    }

    public InsertDataContext(DbContextOptions<InsertDataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employess> Employesses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Insert_data;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employess>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employes__3214EC0758211CC2");

            entity.ToTable("Employess");

            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Department).HasMaxLength(50);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
