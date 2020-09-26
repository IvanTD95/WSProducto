using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WSProducto.Datos.Contexto
{
    public partial class TRUPERContex : DbContext
    {
        public TRUPERContex()
        {
        }

        public TRUPERContex(DbContextOptions<TRUPERContex> options)
            : base(options)
        {
        }

        public virtual DbSet<Producto> Producto { get; set; }

        // Unable to generate entity type for table 'dbo.Pedido'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-6HQC8G9;Database=TRUPER; User ID=sa;Password=sasa;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Sku)
                    .HasName("PK__Producto__CA1ECF0CEBDE23CF");

                entity.Property(e => e.Sku)
                    .HasColumnName("SKU")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.NombreProducto)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("decimal(6, 2)");
            });
        }
    }
}
