using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Facturacion.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(maxLength: 10, nullable: false),
                    Correo = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    CreateAt = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EncabezadoFacturas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(maxLength: 200, nullable: false),
                    CreateAt = table.Column<DateTimeOffset>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncabezadoFacturas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EncabezadoFacturas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemFacturas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(nullable: false),
                    ProductoId = table.Column<int>(nullable: false),
                    FacturaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemFacturas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemFacturas_EncabezadoFacturas_FacturaId",
                        column: x => x.FacturaId,
                        principalTable: "EncabezadoFacturas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemFacturas_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Apellido", "Correo", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "Olivetto", "carsolivetto@gmail.com", "Carson", "5655-7554" },
                    { 2, "Barzdukas", "barzmeredith@hotmail.com", "Meredith", "8965-1568" },
                    { 3, "Anand", "gytanand@gmail.com", "Gytis", "6985-8954" }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CreateAt", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2020, 7, 5, 11, 0, 11, 128, DateTimeKind.Unspecified).AddTicks(4817), new TimeSpan(0, -6, 0, 0, 0)), "Teclado", 20.67m },
                    { 2, new DateTimeOffset(new DateTime(2020, 7, 5, 11, 0, 11, 134, DateTimeKind.Unspecified).AddTicks(3147), new TimeSpan(0, -6, 0, 0, 0)), "Mouse", 5.99m },
                    { 3, new DateTimeOffset(new DateTime(2020, 7, 5, 11, 0, 11, 134, DateTimeKind.Unspecified).AddTicks(3490), new TimeSpan(0, -6, 0, 0, 0)), "Laptop", 850.56m },
                    { 4, new DateTimeOffset(new DateTime(2020, 7, 5, 11, 0, 11, 134, DateTimeKind.Unspecified).AddTicks(3613), new TimeSpan(0, -6, 0, 0, 0)), "Monitor", 50m },
                    { 5, new DateTimeOffset(new DateTime(2020, 7, 5, 11, 0, 11, 134, DateTimeKind.Unspecified).AddTicks(3682), new TimeSpan(0, -6, 0, 0, 0)), "Bocinas", 20.95m },
                    { 6, new DateTimeOffset(new DateTime(2020, 7, 5, 11, 0, 11, 134, DateTimeKind.Unspecified).AddTicks(3752), new TimeSpan(0, -6, 0, 0, 0)), "Audifonos", 30.85m }
                });

            migrationBuilder.InsertData(
                table: "EncabezadoFacturas",
                columns: new[] { "Id", "ClienteId", "CreateAt", "Descripcion" },
                values: new object[] { 1, 1, new DateTimeOffset(new DateTime(2020, 7, 5, 11, 0, 11, 135, DateTimeKind.Unspecified).AddTicks(3188), new TimeSpan(0, -6, 0, 0, 0)), "venta de equipo informatico" });

            migrationBuilder.InsertData(
                table: "EncabezadoFacturas",
                columns: new[] { "Id", "ClienteId", "CreateAt", "Descripcion" },
                values: new object[] { 2, 1, new DateTimeOffset(new DateTime(2020, 7, 5, 11, 0, 11, 135, DateTimeKind.Unspecified).AddTicks(4924), new TimeSpan(0, -6, 0, 0, 0)), "venta de monitor" });

            migrationBuilder.InsertData(
                table: "EncabezadoFacturas",
                columns: new[] { "Id", "ClienteId", "CreateAt", "Descripcion" },
                values: new object[] { 3, 2, new DateTimeOffset(new DateTime(2020, 7, 5, 11, 0, 11, 135, DateTimeKind.Unspecified).AddTicks(5041), new TimeSpan(0, -6, 0, 0, 0)), "venta de audifonos" });

            migrationBuilder.InsertData(
                table: "ItemFacturas",
                columns: new[] { "Id", "Cantidad", "FacturaId", "ProductoId" },
                values: new object[,]
                {
                    { 1, 5, 1, 4 },
                    { 2, 1, 1, 3 },
                    { 3, 8, 1, 1 },
                    { 4, 12, 2, 4 },
                    { 5, 12, 3, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EncabezadoFacturas_ClienteId",
                table: "EncabezadoFacturas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemFacturas_FacturaId",
                table: "ItemFacturas",
                column: "FacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemFacturas_ProductoId",
                table: "ItemFacturas",
                column: "ProductoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemFacturas");

            migrationBuilder.DropTable(
                name: "EncabezadoFacturas");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
