namespace Factoring.Repositorio
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Modelo;

    public partial class FactoringContext : DbContext
    {
        public FactoringContext()
            : base("name=FactoringContext")
        {
        }

        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<ImagenFactura> ImagenFactura { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empresa>()
                .Property(e => e.NuRuc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .HasMany(e => e.Factura)
                .WithRequired(e => e.Empresa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Factura>()
                .Property(e => e.NuFactura)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Factura>()
                .Property(e => e.NuRuc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Factura>()
                .Property(e => e.SsTotFactura)
                .HasPrecision(12, 2);

            modelBuilder.Entity<Factura>()
                .Property(e => e.SsTotImpuestos)
                .HasPrecision(12, 2);

            modelBuilder.Entity<Factura>()
                .HasOptional(e => e.ImagenFactura)
                .WithRequired(e => e.Factura);
        }
    }
}
