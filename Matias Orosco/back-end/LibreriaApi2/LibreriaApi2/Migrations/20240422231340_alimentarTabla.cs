using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibreriaApi2.Migrations
{
    /// <inheritdoc />
    public partial class alimentarTabla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "librerias",
                columns: new[] { "Id", "Creador", "Detalles", "Nombre", "Paginas", "Totales", "fecha", "fechaUpdate" },
                values: new object[,]
                {
                    { 1, "Yo", "Es fuerte", "Superman", 3, 10, new DateTime(2024, 4, 22, 20, 13, 39, 772, DateTimeKind.Local).AddTicks(6402), new DateTime(2024, 4, 22, 20, 13, 39, 772, DateTimeKind.Local).AddTicks(6412) },
                    { 2, "Yo2", "Es fuerte", "Iroman", 4, 14, new DateTime(2024, 4, 22, 20, 13, 39, 772, DateTimeKind.Local).AddTicks(6414), new DateTime(2024, 4, 22, 20, 13, 39, 772, DateTimeKind.Local).AddTicks(6415) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "librerias",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "librerias",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
