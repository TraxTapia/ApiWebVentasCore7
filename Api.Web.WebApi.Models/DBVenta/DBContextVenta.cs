using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Web.WebApi.Models.DBVenta
{
    public class DBContextVenta : DbContext
    {
        
        public DBContextVenta(DbContextOptions<DBContextVenta> contextOptions) : base(contextOptions)
        {

        }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Detalle_Venta> Detalle_Venta { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
       //     modelBuilder.Entity<Categoria>()
       //.HasOne(c => c.oProducto)
       //.WithOne(p => p.Categoria)
       //.HasForeignKey<Producto>(p => p.IdCategoria);

            //      modelBuilder.Entity<Producto>()
            //.HasOne(p => p.Categoria)
            //.WithOne(c => c.oProducto)
            //.HasForeignKey<Categoria>(c => c.IdCategoria);

            modelBuilder.Entity<Categoria>()
                 .Property(e => e.Descripcion)
                 .IsUnicode(false);

            modelBuilder.Entity<Detalle_Venta>()
                .Property(e => e.PrecioVenta)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Detalle_Venta>()
                .Property(e => e.Total)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Codigo)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.PrecioCompra)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Producto>()
                .Property(e => e.PrecioVenta)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.NombreCompleto)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Correo)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Clave)
                .IsUnicode(false);

            modelBuilder.Entity<Venta>()
                .Property(e => e.TipoPago)
                .IsUnicode(false);

            modelBuilder.Entity<Venta>()
                .Property(e => e.NumeroDocumento)
                .IsUnicode(false);

            modelBuilder.Entity<Venta>()
                .Property(e => e.DocumentoCliente)
                .IsUnicode(false);

            modelBuilder.Entity<Venta>()
                .Property(e => e.NombreCliente)
                .IsUnicode(false);

            modelBuilder.Entity<Venta>()
                .Property(e => e.MontoPagoCon)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Venta>()
                .Property(e => e.MontoCambio)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Venta>()
                .Property(e => e.MontoSubTotal)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Venta>()
                .Property(e => e.MontoIGV)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Venta>()
                .Property(e => e.MontoTotal)
                .HasPrecision(10, 2);
        }
    }
}
