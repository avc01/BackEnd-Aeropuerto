﻿// <auto-generated />
using System;
using BackEnd_Aeropuerto.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BackEnd_Aeropuerto.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211026224749_new-model-v7")]
    partial class newmodelv7
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BackEnd_Aeropuerto.Models.Aerolinea", b =>
                {
                    b.Property<int>("AerolineaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ConsecutivoId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AerolineaId");

                    b.HasIndex("ConsecutivoId")
                        .IsUnique();

                    b.ToTable("Aerolineas");
                });

            modelBuilder.Entity("BackEnd_Aeropuerto.Models.Bitacora", b =>
                {
                    b.Property<int>("BitacoraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Detalle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaHora")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("BitacoraId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Bitacoras");
                });

            modelBuilder.Entity("BackEnd_Aeropuerto.Models.Compra", b =>
                {
                    b.Property<int>("CompraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("ConsecutivoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaHora")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int>("VueloId")
                        .HasColumnType("int");

                    b.HasKey("CompraId");

                    b.HasIndex("ConsecutivoId")
                        .IsUnique();

                    b.HasIndex("UsuarioId");

                    b.HasIndex("VueloId");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("BackEnd_Aeropuerto.Models.Consecutivo", b =>
                {
                    b.Property<int>("ConsecutivoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroConsecutivo")
                        .HasColumnType("int");

                    b.Property<string>("Prefijo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RangoFinal")
                        .HasColumnType("int");

                    b.Property<int?>("RangoInicial")
                        .HasColumnType("int");

                    b.HasKey("ConsecutivoId");

                    b.ToTable("Consecutivos");
                });

            modelBuilder.Entity("BackEnd_Aeropuerto.Models.Error", b =>
                {
                    b.Property<int>("ErrorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaHora")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Mensaje")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.HasKey("ErrorId");

                    b.ToTable("Errores");
                });

            modelBuilder.Entity("BackEnd_Aeropuerto.Models.EstadoVuelo", b =>
                {
                    b.Property<int>("EstadoVueloId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EstadoVueloId");

                    b.ToTable("EstadoVuelos");
                });

            modelBuilder.Entity("BackEnd_Aeropuerto.Models.Pais", b =>
                {
                    b.Property<int>("PaisId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ConsecutivoId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PaisId");

                    b.HasIndex("ConsecutivoId")
                        .IsUnique();

                    b.ToTable("Paises");
                });

            modelBuilder.Entity("BackEnd_Aeropuerto.Models.Puerta", b =>
                {
                    b.Property<int>("PuertaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ConsecutivoId")
                        .HasColumnType("int");

                    b.Property<string>("Detalle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroPuerta")
                        .HasColumnType("int");

                    b.HasKey("PuertaId");

                    b.HasIndex("ConsecutivoId")
                        .IsUnique();

                    b.ToTable("Puertas");
                });

            modelBuilder.Entity("BackEnd_Aeropuerto.Models.Reserva", b =>
                {
                    b.Property<int>("ReservaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BookingId")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("ConsecutivoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaHora")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("NumeroReservacion")
                        .HasColumnType("int");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int>("VueloId")
                        .HasColumnType("int");

                    b.HasKey("ReservaId");

                    b.HasIndex("ConsecutivoId")
                        .IsUnique();

                    b.HasIndex("UsuarioId");

                    b.HasIndex("VueloId");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("BackEnd_Aeropuerto.Models.Rol", b =>
                {
                    b.Property<int>("RolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("RolId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("BackEnd_Aeropuerto.Models.Tarjeta", b =>
                {
                    b.Property<int>("TarjetaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodigoTarjeta")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaExp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroTarjeta")
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("TarjetaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Tarjetas");
                });

            modelBuilder.Entity("BackEnd_Aeropuerto.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConfirmaContraseña")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pregunta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Respuesta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("BackEnd_Aeropuerto.Models.Vuelo", b =>
                {
                    b.Property<int>("VueloId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AerolineaId")
                        .HasColumnType("int");

                    b.Property<int>("ConsecutivoId")
                        .HasColumnType("int");

                    b.Property<string>("Destino")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstadoVueloId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaHora")
                        .HasColumnType("datetime2");

                    b.Property<string>("Procedencia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PuertaId")
                        .HasColumnType("int");

                    b.HasKey("VueloId");

                    b.HasIndex("AerolineaId");

                    b.HasIndex("ConsecutivoId")
                        .IsUnique();

                    b.HasIndex("EstadoVueloId");

                    b.HasIndex("PuertaId");

                    b.ToTable("Vuelos");
                });

            modelBuilder.Entity("RolUsuario", b =>
                {
                    b.Property<int>("RolesRolId")
                        .HasColumnType("int");

                    b.Property<int>("UsuariosUsuarioId")
                        .HasColumnType("int");

                    b.HasKey("RolesRolId", "UsuariosUsuarioId");

                    b.HasIndex("UsuariosUsuarioId");

                    b.ToTable("RolUsuario");
                });

            modelBuilder.Entity("BackEnd_Aeropuerto.Models.Aerolinea", b =>
                {
                    b.HasOne("BackEnd_Aeropuerto.Models.Consecutivo", "Consecutivos")
                        .WithOne("Aerolineas")
                        .HasForeignKey("BackEnd_Aeropuerto.Models.Aerolinea", "ConsecutivoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Consecutivos");
                });

            modelBuilder.Entity("BackEnd_Aeropuerto.Models.Bitacora", b =>
                {
                    b.HasOne("BackEnd_Aeropuerto.Models.Usuario", "Usuarios")
                        .WithMany("Bitacoras")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("BackEnd_Aeropuerto.Models.Compra", b =>
                {
                    b.HasOne("BackEnd_Aeropuerto.Models.Consecutivo", "Consecutivos")
                        .WithOne("Compras")
                        .HasForeignKey("BackEnd_Aeropuerto.Models.Compra", "ConsecutivoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEnd_Aeropuerto.Models.Usuario", "Usuarios")
                        .WithMany("Compras")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEnd_Aeropuerto.Models.Vuelo", "Vuelos")
                        .WithMany()
                        .HasForeignKey("VueloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Consecutivos");

                    b.Navigation("Usuarios");

                    b.Navigation("Vuelos");
                });

            modelBuilder.Entity("BackEnd_Aeropuerto.Models.Pais", b =>
                {
                    b.HasOne("BackEnd_Aeropuerto.Models.Consecutivo", "Consecutivos")
                        .WithOne("Paises")
                        .HasForeignKey("BackEnd_Aeropuerto.Models.Pais", "ConsecutivoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Consecutivos");
                });

            modelBuilder.Entity("BackEnd_Aeropuerto.Models.Puerta", b =>
                {
                    b.HasOne("BackEnd_Aeropuerto.Models.Consecutivo", "Consecutivos")
                        .WithOne("Puertas")
                        .HasForeignKey("BackEnd_Aeropuerto.Models.Puerta", "ConsecutivoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Consecutivos");
                });

            modelBuilder.Entity("BackEnd_Aeropuerto.Models.Reserva", b =>
                {
                    b.HasOne("BackEnd_Aeropuerto.Models.Consecutivo", "Consecutivos")
                        .WithOne("Reservas")
                        .HasForeignKey("BackEnd_Aeropuerto.Models.Reserva", "ConsecutivoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEnd_Aeropuerto.Models.Usuario", "Usuarios")
                        .WithMany("Reservas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEnd_Aeropuerto.Models.Vuelo", "Vuelos")
                        .WithMany()
                        .HasForeignKey("VueloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Consecutivos");

                    b.Navigation("Usuarios");

                    b.Navigation("Vuelos");
                });

            modelBuilder.Entity("BackEnd_Aeropuerto.Models.Tarjeta", b =>
                {
                    b.HasOne("BackEnd_Aeropuerto.Models.Usuario", "Usuarios")
                        .WithMany("Tarjetas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("BackEnd_Aeropuerto.Models.Vuelo", b =>
                {
                    b.HasOne("BackEnd_Aeropuerto.Models.Aerolinea", "Aerolineas")
                        .WithMany("Vuelos")
                        .HasForeignKey("AerolineaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BackEnd_Aeropuerto.Models.Consecutivo", "Consecutivos")
                        .WithOne("Vuelos")
                        .HasForeignKey("BackEnd_Aeropuerto.Models.Vuelo", "ConsecutivoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BackEnd_Aeropuerto.Models.EstadoVuelo", "EstadoVuelos")
                        .WithMany("Vuelos")
                        .HasForeignKey("EstadoVueloId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BackEnd_Aeropuerto.Models.Puerta", "Puertas")
                        .WithMany("Vuelos")
                        .HasForeignKey("PuertaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Aerolineas");

                    b.Navigation("Consecutivos");

                    b.Navigation("EstadoVuelos");

                    b.Navigation("Puertas");
                });

            modelBuilder.Entity("RolUsuario", b =>
                {
                    b.HasOne("BackEnd_Aeropuerto.Models.Rol", null)
                        .WithMany()
                        .HasForeignKey("RolesRolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEnd_Aeropuerto.Models.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UsuariosUsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BackEnd_Aeropuerto.Models.Aerolinea", b =>
                {
                    b.Navigation("Vuelos");
                });

            modelBuilder.Entity("BackEnd_Aeropuerto.Models.Consecutivo", b =>
                {
                    b.Navigation("Aerolineas");

                    b.Navigation("Compras");

                    b.Navigation("Paises");

                    b.Navigation("Puertas");

                    b.Navigation("Reservas");

                    b.Navigation("Vuelos");
                });

            modelBuilder.Entity("BackEnd_Aeropuerto.Models.EstadoVuelo", b =>
                {
                    b.Navigation("Vuelos");
                });

            modelBuilder.Entity("BackEnd_Aeropuerto.Models.Puerta", b =>
                {
                    b.Navigation("Vuelos");
                });

            modelBuilder.Entity("BackEnd_Aeropuerto.Models.Usuario", b =>
                {
                    b.Navigation("Bitacoras");

                    b.Navigation("Compras");

                    b.Navigation("Reservas");

                    b.Navigation("Tarjetas");
                });
#pragma warning restore 612, 618
        }
    }
}
