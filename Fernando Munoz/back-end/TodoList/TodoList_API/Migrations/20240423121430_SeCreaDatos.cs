using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TodoList_API.Migrations
{
    /// <inheritdoc />
    public partial class SeCreaDatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tareas",
                columns: new[] { "Id", "Detalle", "FechaActualizacion", "FechaCreacion", "FechaEliminacion", "Titulo", "UsuarioCreador" },
                values: new object[,]
                {
                    { 1, "hola", new DateTime(2024, 4, 23, 9, 14, 30, 403, DateTimeKind.Local).AddTicks(4903), new DateTime(2024, 4, 23, 9, 14, 30, 403, DateTimeKind.Local).AddTicks(4889), new DateTime(2024, 4, 23, 9, 14, 30, 403, DateTimeKind.Local).AddTicks(4904), "Sacar a pasear perros", 1 },
                    { 2, "hola", new DateTime(2024, 4, 23, 9, 14, 30, 403, DateTimeKind.Local).AddTicks(4907), new DateTime(2024, 4, 23, 9, 14, 30, 403, DateTimeKind.Local).AddTicks(4906), new DateTime(2024, 4, 23, 9, 14, 30, 403, DateTimeKind.Local).AddTicks(4908), "Ir a hacer las compras", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
