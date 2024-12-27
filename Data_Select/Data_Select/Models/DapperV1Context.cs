using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Data_Select.Models;

public partial class DapperV1Context : DbContext
{
    public DapperV1Context()
    {
    }

    public DapperV1Context(DbContextOptions<DapperV1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<DataSelect> DataSelects { get; set; }

    public virtual DbSet<Employess> Employesses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Dapper_v1;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DataSelect>(entity =>
        {
            entity.ToTable("DataSelect");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(400);
            entity.Property(e => e.OrderByFile).HasMaxLength(200);
            entity.Property(e => e.SelectFile)
                .HasMaxLength(200)
                .HasColumnName("selectFile");
        });

        modelBuilder.Entity<Employess>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employes__3214EC07152B921B");

            entity.ToTable("Employess");

            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.Department).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
