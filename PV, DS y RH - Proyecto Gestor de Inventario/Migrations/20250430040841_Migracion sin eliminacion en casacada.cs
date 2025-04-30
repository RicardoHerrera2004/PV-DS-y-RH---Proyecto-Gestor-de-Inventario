using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PV__DS_y_RH___Proyecto_Gestor_de_Inventario.Migrations
{
    /// <inheritdoc />
    public partial class Migracionsineliminacionencasacada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[,]
                {
                    { 1, "Prendas de vestir: camisetas, pantalones, chaquetas…", "Ropa" },
                    { 2, "Alimentos en conserva, envasados y frescos.", "Comida" },
                    { 3, "Bebidas alcohólicas y no alcohólicas.", "Bebidas" },
                    { 4, "Productos de despensa: cereales, lácteos, granos.", "Abarrotes" },
                    { 5, "Collares, anillos, pulseras y accesorios metálicos.", "Joyas" },
                    { 6, "Medicamentos y productos de cuidado de la salud.", "Fármacos" },
                    { 7, "Artículos diversos que no encajan en las categorías anteriores.", "Otros" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
