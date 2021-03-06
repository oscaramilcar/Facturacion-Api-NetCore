﻿// <auto-generated />
using System;
using Facturacion.API.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Facturacion.API.Migrations
{
    [DbContext(typeof(FacturacionContext))]
    [Migration("20200705170011_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Facturacion.API.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("Clientes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Apellido = "Olivetto",
                            Correo = "carsolivetto@gmail.com",
                            Nombre = "Carson",
                            Telefono = "5655-7554"
                        },
                        new
                        {
                            Id = 2,
                            Apellido = "Barzdukas",
                            Correo = "barzmeredith@hotmail.com",
                            Nombre = "Meredith",
                            Telefono = "8965-1568"
                        },
                        new
                        {
                            Id = 3,
                            Apellido = "Anand",
                            Correo = "gytanand@gmail.com",
                            Nombre = "Gytis",
                            Telefono = "6985-8954"
                        });
                });

            modelBuilder.Entity("Facturacion.API.Entities.EncabezadoFactura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CreateAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("EncabezadoFacturas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClienteId = 1,
                            CreateAt = new DateTimeOffset(new DateTime(2020, 7, 5, 11, 0, 11, 135, DateTimeKind.Unspecified).AddTicks(3188), new TimeSpan(0, -6, 0, 0, 0)),
                            Descripcion = "venta de equipo informatico"
                        },
                        new
                        {
                            Id = 2,
                            ClienteId = 1,
                            CreateAt = new DateTimeOffset(new DateTime(2020, 7, 5, 11, 0, 11, 135, DateTimeKind.Unspecified).AddTicks(4924), new TimeSpan(0, -6, 0, 0, 0)),
                            Descripcion = "venta de monitor"
                        },
                        new
                        {
                            Id = 3,
                            ClienteId = 2,
                            CreateAt = new DateTimeOffset(new DateTime(2020, 7, 5, 11, 0, 11, 135, DateTimeKind.Unspecified).AddTicks(5041), new TimeSpan(0, -6, 0, 0, 0)),
                            Descripcion = "venta de audifonos"
                        });
                });

            modelBuilder.Entity("Facturacion.API.Entities.ItemFactura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("FacturaId")
                        .HasColumnType("int");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FacturaId");

                    b.HasIndex("ProductoId");

                    b.ToTable("ItemFacturas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cantidad = 5,
                            FacturaId = 1,
                            ProductoId = 4
                        },
                        new
                        {
                            Id = 2,
                            Cantidad = 1,
                            FacturaId = 1,
                            ProductoId = 3
                        },
                        new
                        {
                            Id = 3,
                            Cantidad = 8,
                            FacturaId = 1,
                            ProductoId = 1
                        },
                        new
                        {
                            Id = 4,
                            Cantidad = 12,
                            FacturaId = 2,
                            ProductoId = 4
                        },
                        new
                        {
                            Id = 5,
                            Cantidad = 12,
                            FacturaId = 3,
                            ProductoId = 6
                        });
                });

            modelBuilder.Entity("Facturacion.API.Entities.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreateAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.ToTable("Productos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateAt = new DateTimeOffset(new DateTime(2020, 7, 5, 11, 0, 11, 128, DateTimeKind.Unspecified).AddTicks(4817), new TimeSpan(0, -6, 0, 0, 0)),
                            Nombre = "Teclado",
                            Precio = 20.67m
                        },
                        new
                        {
                            Id = 2,
                            CreateAt = new DateTimeOffset(new DateTime(2020, 7, 5, 11, 0, 11, 134, DateTimeKind.Unspecified).AddTicks(3147), new TimeSpan(0, -6, 0, 0, 0)),
                            Nombre = "Mouse",
                            Precio = 5.99m
                        },
                        new
                        {
                            Id = 3,
                            CreateAt = new DateTimeOffset(new DateTime(2020, 7, 5, 11, 0, 11, 134, DateTimeKind.Unspecified).AddTicks(3490), new TimeSpan(0, -6, 0, 0, 0)),
                            Nombre = "Laptop",
                            Precio = 850.56m
                        },
                        new
                        {
                            Id = 4,
                            CreateAt = new DateTimeOffset(new DateTime(2020, 7, 5, 11, 0, 11, 134, DateTimeKind.Unspecified).AddTicks(3613), new TimeSpan(0, -6, 0, 0, 0)),
                            Nombre = "Monitor",
                            Precio = 50m
                        },
                        new
                        {
                            Id = 5,
                            CreateAt = new DateTimeOffset(new DateTime(2020, 7, 5, 11, 0, 11, 134, DateTimeKind.Unspecified).AddTicks(3682), new TimeSpan(0, -6, 0, 0, 0)),
                            Nombre = "Bocinas",
                            Precio = 20.95m
                        },
                        new
                        {
                            Id = 6,
                            CreateAt = new DateTimeOffset(new DateTime(2020, 7, 5, 11, 0, 11, 134, DateTimeKind.Unspecified).AddTicks(3752), new TimeSpan(0, -6, 0, 0, 0)),
                            Nombre = "Audifonos",
                            Precio = 30.85m
                        });
                });

            modelBuilder.Entity("Facturacion.API.Entities.EncabezadoFactura", b =>
                {
                    b.HasOne("Facturacion.API.Entities.Cliente", "Cliente")
                        .WithMany("Facturas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Facturacion.API.Entities.ItemFactura", b =>
                {
                    b.HasOne("Facturacion.API.Entities.EncabezadoFactura", "Factura")
                        .WithMany("ItemFacturas")
                        .HasForeignKey("FacturaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Facturacion.API.Entities.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
