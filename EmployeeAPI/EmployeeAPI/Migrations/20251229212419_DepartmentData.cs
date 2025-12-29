using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeeAPI.Migrations
{
    /// <inheritdoc />
    public partial class DepartmentData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "CodeDepartment", "NameDepartment" },
                values: new object[,]
                {
                    { 1, "Dirección general" },
                    { 2, "Talento Humano" },
                    { 3, "Finanzas" },
                    { 4, "Marketing" },
                    { 5, "Comercial" },
                    { 6, "Operaciones" },
                    { 7, "Compras y Logística" },
                    { 8, "Tecnología" },
                    { 9, "Atención al Cliente" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "CodeDepartment",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "CodeDepartment",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "CodeDepartment",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "CodeDepartment",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "CodeDepartment",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "CodeDepartment",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "CodeDepartment",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "CodeDepartment",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "CodeDepartment",
                keyValue: 9);
        }
    }
}
