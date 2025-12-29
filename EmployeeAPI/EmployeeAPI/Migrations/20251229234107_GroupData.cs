using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeeAPI.Migrations
{
    /// <inheritdoc />
    public partial class GroupData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "CodeGroup", "CodeDepartment", "NameGroup" },
                values: new object[,]
                {
                    { 1, 2, "Reclutamiento" },
                    { 2, 2, "Compensación y beneficios" },
                    { 3, 2, "Capacitación" },
                    { 4, 2, "Relaciones Laborales" },
                    { 5, 2, "Nominas" },
                    { 6, 2, "Gestión de desempeño" },
                    { 7, 3, "Contabilidad" },
                    { 8, 3, "Tesorería" },
                    { 9, 3, "Planificación" },
                    { 10, 3, "Gestión de riesgo" },
                    { 11, 3, "Impuestos" },
                    { 12, 4, "Marketing digital" },
                    { 13, 4, "Estrategia de marca" },
                    { 14, 4, "Redes sociales" },
                    { 15, 5, "Ventas" },
                    { 16, 6, "Producción" },
                    { 17, 8, "Infraestructura y redes" },
                    { 18, 8, "Ciber seguridad" },
                    { 19, 8, "Desarrollo e I+D" },
                    { 20, 8, "Soporte y helpdesk" },
                    { 21, 8, "Data" },
                    { 22, 8, "Gestión de proyectos" },
                    { 23, 9, "Atención al cliente" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "CodeGroup",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "CodeGroup",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "CodeGroup",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "CodeGroup",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "CodeGroup",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "CodeGroup",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "CodeGroup",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "CodeGroup",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "CodeGroup",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "CodeGroup",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "CodeGroup",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "CodeGroup",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "CodeGroup",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "CodeGroup",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "CodeGroup",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "CodeGroup",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "CodeGroup",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "CodeGroup",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "CodeGroup",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "CodeGroup",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "CodeGroup",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "CodeGroup",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "CodeGroup",
                keyValue: 23);
        }
    }
}
