﻿// <auto-generated />
using System;
using LibreriaApi.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibreriaApi2.Migrations
{
    [DbContext(typeof(AplicationDbContext))]
    partial class AplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LibreriaApi.Modelos.Libreria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Creador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Detalles")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Paginas")
                        .HasColumnType("int");

                    b.Property<int>("Totales")
                        .HasColumnType("int");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fechaUpdate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("librerias");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Creador = "Yo",
                            Detalles = "Es fuerte",
                            Nombre = "Superman",
                            Paginas = 3,
                            Totales = 10,
                            fecha = new DateTime(2024, 4, 22, 20, 13, 39, 772, DateTimeKind.Local).AddTicks(6402),
                            fechaUpdate = new DateTime(2024, 4, 22, 20, 13, 39, 772, DateTimeKind.Local).AddTicks(6412)
                        },
                        new
                        {
                            Id = 2,
                            Creador = "Yo2",
                            Detalles = "Es fuerte",
                            Nombre = "Iroman",
                            Paginas = 4,
                            Totales = 14,
                            fecha = new DateTime(2024, 4, 22, 20, 13, 39, 772, DateTimeKind.Local).AddTicks(6414),
                            fechaUpdate = new DateTime(2024, 4, 22, 20, 13, 39, 772, DateTimeKind.Local).AddTicks(6415)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
