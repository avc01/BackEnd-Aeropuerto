using BackEnd_Aeropuerto.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Aeropuerto.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Aerolinea> Aerolineas { get; set; }

        public DbSet<Error> Errores { get; set; }

        public DbSet<Vuelo> Vuelos { get; set; }

        public DbSet<Pais> Paises { get; set; }

        public DbSet<EstadoVuelo> EstadoVuelos { get; set; }

        public DbSet<Puerta> Puertas { get; set; }

        public DbSet<Compra> Compras { get; set; }

        public DbSet<Tarjeta> Tarjetas { get; set; }

        public DbSet<Reserva> Reservas { get; set; }

        public DbSet<Rol> Roles { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Bitacora> Bitacoras { get; set; }

        public DbSet<Consecutivo> Consecutivos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vuelo>()
                .HasOne(x => x.Consecutivos)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vuelo>()
                .HasOne(x => x.Aerolineas)
                .WithMany(x => x.Vuelos)
                .HasForeignKey(x => x.AerolineaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vuelo>()
               .HasOne(x => x.Puertas)
               .WithMany(x => x.Vuelos)
               .HasForeignKey(x => x.PuertaId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vuelo>()
               .HasOne(x => x.EstadoVuelos)
               .WithMany(x => x.Vuelos)
               .HasForeignKey(x => x.EstadoVueloId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
