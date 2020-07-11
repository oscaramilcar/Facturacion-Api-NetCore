using Facturacion.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facturacion.API.Context
{
    public class FacturacionContext : DbContext
    {
        public FacturacionContext(DbContextOptions<FacturacionContext> options) : base(options)
        {

        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<EncabezadoFactura> EncabezadoFacturas { get; set; }
        public DbSet<ItemFactura> ItemFacturas { get; set; }
        public DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Producto>().Property(p => p.Precio).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<Producto>().HasData(new Producto()
            {
                Id = 1,
                Nombre = "Teclado",
                Precio = 20.67M,
                CreateAt = DateTime.Now
            });
            modelBuilder.Entity<Producto>().HasData(new Producto()
            {
                Id = 2,
                Nombre = "Mouse",
                Precio = 5.99M,
                CreateAt = DateTime.Now
            });
            modelBuilder.Entity<Producto>().HasData(new Producto()
            {
                Id = 3,
                Nombre = "Laptop",
                Precio = 850.56M,
                CreateAt = DateTime.Now
            });
            modelBuilder.Entity<Producto>().HasData(new Producto()
            {
                Id = 4,
                Nombre = "Monitor",
                Precio = 50M,
                CreateAt = DateTime.Now
            });
            modelBuilder.Entity<Producto>().HasData(new Producto()
            {
                Id = 5,
                Nombre = "Bocinas",
                Precio = 20.95M,
                CreateAt = DateTime.Now
            });
            modelBuilder.Entity<Producto>().HasData(new Producto()
            {
                Id = 6,
                Nombre = "Audifonos",
                Precio = 30.85M,
                CreateAt = DateTime.Now
            });
            modelBuilder.Entity<Cliente>().HasData(new Cliente(){
                Id = 1,
                Nombre = "Carson",
                Apellido = "Olivetto",
                Telefono = "5655-7554",
                Correo = "carsolivetto@gmail.com",
            });
            modelBuilder.Entity<Cliente>().HasData(new Cliente(){
                Id = 2,
                Nombre = "Meredith",
                Apellido = "Barzdukas",
                Telefono = "8965-1568",
                Correo = "barzmeredith@hotmail.com"
            });
            modelBuilder.Entity<Cliente>().HasData(new Cliente(){
                Id = 3,
                Nombre = "Gytis",
                Apellido = "Anand",
                Telefono = "6985-8954",
                Correo = "gytanand@gmail.com"
            });
            modelBuilder.Entity<EncabezadoFactura>().HasData(new EncabezadoFactura(){
                Id = 1,
                Descripcion = "venta de equipo informatico",
                CreateAt = DateTime.Now,
                ClienteId = 1
            });
            modelBuilder.Entity<EncabezadoFactura>().HasData(new EncabezadoFactura(){
                Id = 2,
                Descripcion = "venta de monitor",
                CreateAt = DateTime.Now,
                ClienteId = 1
            });
            modelBuilder.Entity<EncabezadoFactura>().HasData(new EncabezadoFactura(){
                Id = 3,
                Descripcion = "venta de audifonos",
                CreateAt = DateTime.Now,
                ClienteId = 2
            });
            modelBuilder.Entity<ItemFactura>().HasData(new ItemFactura(){
                Id = 1,
                Cantidad = 5,
                ProductoId = 4,
                FacturaId = 1
            });
            modelBuilder.Entity<ItemFactura>().HasData(new ItemFactura(){
                Id = 2,
                Cantidad = 1,
                ProductoId = 3,
                FacturaId = 1
            });
            modelBuilder.Entity<ItemFactura>().HasData(new ItemFactura(){
                Id = 3,
                Cantidad = 8,
                ProductoId = 1,
                FacturaId = 1
            });
            modelBuilder.Entity<ItemFactura>().HasData(new ItemFactura(){
                Id = 4,
                Cantidad = 12,
                ProductoId = 4,
                FacturaId = 2
            });
            modelBuilder.Entity<ItemFactura>().HasData(new ItemFactura(){
                Id = 5,
                Cantidad = 12,
                ProductoId = 6,
                FacturaId = 3
            });
         }
    }
}
