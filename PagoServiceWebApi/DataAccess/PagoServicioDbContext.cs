using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PagoServicioDbContext : DbContext
    {
        public virtual DbSet<MetodoDePago> MetodosDePago { get; set; }
        public virtual DbSet<Pago> Pagos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        public PagoServicioDbContext()
        {
        }

        public PagoServicioDbContext(DbContextOptions<PagoServicioDbContext> options) : base(options: options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.UsuarioNombre)
                .IsUnique();
        }
    }
}
