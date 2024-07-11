using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SysGestionGym.EntidadDeNegocio;

public partial class BdContext : DbContext
{
    public BdContext()
    {
    }

    public BdContext(DbContextOptions<BdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Cliente { get; set; }

    public virtual DbSet<Membresia> Membresia { get; set; }

    public virtual DbSet<Pago> Pago { get; set; }

    public virtual DbSet<Rol> Rol { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("workstation id=BDGym2024.mssql.somee.com;packet size=4096;user id=William904_SQLLogin_1;pwd=81arnctd8m;data source=BDGym2024.mssql.somee.com;persist security info=False;initial catalog=BDGym2024;TrustServerCertificate=True");

   /* protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Cliente__D5946642DB1C779C");
        });

        modelBuilder.Entity<Membresia>(entity =>
        {
            entity.HasKey(e => e.IdMembresia).HasName("PK__Membresi__A76E8B16333D1911");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.IdPago).HasName("PK__Pago__FC851A3AA2A5000A");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Pago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pagos_Cliente");

            entity.HasOne(d => d.IdMembresiaNavigation).WithMany(p => p.Pago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pagos_Membresia");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Pago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pagos_Usuario");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__2A49584C5C662472");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF97E38B124B");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuarios_Rol");
        });

        OnModelCreatingPartial(modelBuilder);
    }
   */
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
