﻿// <auto-generated />
using System;
using BovinoRemoto.App.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BovinoRemoto.App.Persistencia.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20220903022709_Update")]
    partial class Update
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("BovinoRemoto.App.Dominio.Dueño", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Dueños");
                });

            modelBuilder.Entity("BovinoRemoto.App.Dominio.Historia_Clinica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("HistoriasClinicas");
                });

            modelBuilder.Entity("BovinoRemoto.App.Dominio.Recomendacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VisitaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VisitaId");

                    b.ToTable("Recomendaciones");
                });

            modelBuilder.Entity("BovinoRemoto.App.Dominio.Signo_Vital", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("TipoSigno")
                        .HasColumnType("int");

                    b.Property<int>("Valor")
                        .HasColumnType("int");

                    b.Property<int?>("VisitaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VisitaId");

                    b.ToTable("SignosVitales");
                });

            modelBuilder.Entity("BovinoRemoto.App.Dominio.Vaca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("DueñoId")
                        .HasColumnType("int");

                    b.Property<string>("Especie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HistoriaClinicaId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Raza")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VeterinarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DueñoId");

                    b.HasIndex("HistoriaClinicaId");

                    b.HasIndex("VeterinarioId");

                    b.ToTable("Vacas");
                });

            modelBuilder.Entity("BovinoRemoto.App.Dominio.Veterinario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TarjetaProfesional")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Veterinarios");
                });

            modelBuilder.Entity("BovinoRemoto.App.Dominio.Visita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("EstadoAnimo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Historia_ClinicaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Historia_ClinicaId");

                    b.ToTable("Visitas");
                });

            modelBuilder.Entity("BovinoRemoto.App.Dominio.Recomendacion", b =>
                {
                    b.HasOne("BovinoRemoto.App.Dominio.Visita", null)
                        .WithMany("Recomendaciones")
                        .HasForeignKey("VisitaId");
                });

            modelBuilder.Entity("BovinoRemoto.App.Dominio.Signo_Vital", b =>
                {
                    b.HasOne("BovinoRemoto.App.Dominio.Visita", null)
                        .WithMany("SignosVitales")
                        .HasForeignKey("VisitaId");
                });

            modelBuilder.Entity("BovinoRemoto.App.Dominio.Vaca", b =>
                {
                    b.HasOne("BovinoRemoto.App.Dominio.Dueño", "Dueño")
                        .WithMany()
                        .HasForeignKey("DueñoId");

                    b.HasOne("BovinoRemoto.App.Dominio.Historia_Clinica", "HistoriaClinica")
                        .WithMany()
                        .HasForeignKey("HistoriaClinicaId");

                    b.HasOne("BovinoRemoto.App.Dominio.Veterinario", "Veterinario")
                        .WithMany()
                        .HasForeignKey("VeterinarioId");

                    b.Navigation("Dueño");

                    b.Navigation("HistoriaClinica");

                    b.Navigation("Veterinario");
                });

            modelBuilder.Entity("BovinoRemoto.App.Dominio.Visita", b =>
                {
                    b.HasOne("BovinoRemoto.App.Dominio.Historia_Clinica", null)
                        .WithMany("Visitas")
                        .HasForeignKey("Historia_ClinicaId");
                });

            modelBuilder.Entity("BovinoRemoto.App.Dominio.Historia_Clinica", b =>
                {
                    b.Navigation("Visitas");
                });

            modelBuilder.Entity("BovinoRemoto.App.Dominio.Visita", b =>
                {
                    b.Navigation("Recomendaciones");

                    b.Navigation("SignosVitales");
                });
#pragma warning restore 612, 618
        }
    }
}