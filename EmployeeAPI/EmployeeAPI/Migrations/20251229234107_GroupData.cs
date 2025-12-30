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
                    { 1, 1, "Junta Directiva" },
                    { 2, 2, "Reclutamiento" },
                    { 3, 2, "Compensación y beneficios" },
                    { 4, 2, "Capacitación" },
                    { 5, 2, "Relaciones Laborales" },
                    { 6, 2, "Nominas" },
                    { 7, 2, "Gestión de desempeño" },
                    { 8, 3, "Contabilidad" },
                    { 9, 3, "Tesorería" },
                    { 10, 3, "Planificación" },
                    { 11, 3, "Gestión de riesgo" },
                    { 12, 3, "Impuestos" },
                    { 13, 4, "Marketing digital" },
                    { 14, 4, "Estrategia de marca" },
                    { 15, 4, "Redes sociales" },
                    { 16, 5, "Ventas" },
                    { 17, 6, "Producción" },
                    { 18, 8, "Infraestructura y redes" },
                    { 19, 8, "Ciber seguridad" },
                    { 20, 8, "Desarrollo e I+D" },
                    { 21, 8, "Soporte y helpdesk" },
                    { 22, 8, "Data" },
                    { 23, 8, "Gestión de proyectos" },
                    { 24, 9, "Atención al cliente" }
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
