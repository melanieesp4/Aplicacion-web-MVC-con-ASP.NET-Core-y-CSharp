using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ListadoBecasApp.Models;

public partial class BecasAppContext : DbContext
{
    public BecasAppContext()
    {
    }

    public BecasAppContext(DbContextOptions<BecasAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Beca> Becas { get; set; }

    public virtual DbSet<Carrera> Carreras { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 

   }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Beca>(entity =>
        {
            entity.HasKey(e => e.IdBeca).HasName("PK__Becas__D3DAB53C5C2E3B88");

            entity.Property(e => e.IdBeca).HasColumnName("idBeca");
            entity.Property(e => e.Descripcion).HasMaxLength(200);
            entity.Property(e => e.IdCarrera).HasColumnName("idCarrera");
            entity.Property(e => e.NombreBeca)
                .HasMaxLength(100)
                .HasColumnName("nombreBeca");

            entity.HasOne(d => d.IdCarreraNavigation).WithMany(p => p.Becas)
                .HasForeignKey(d => d.IdCarrera)
                .HasConstraintName("FK_Becas_Carreras");
        });

        modelBuilder.Entity<Carrera>(entity =>
        {
            entity.HasKey(e => e.IdCarrera).HasName("PK__Carreras__7B19E791367D332C");

            entity.Property(e => e.IdCarrera).HasColumnName("idCarrera");
            entity.Property(e => e.NombreCarrera).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
