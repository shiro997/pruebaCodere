using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    CodeDepartment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameDepartment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.CodeDepartment);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    CodeGroup = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeDepartment = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.CodeGroup);
                    table.ForeignKey(
                        name: "FK_Groups_Departments_CodeDepartment",
                        column: x => x.CodeDepartment,
                        principalTable: "Departments",
                        principalColumn: "CodeDepartment",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    CodeEmployee = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEmployee = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CodeGroup = table.Column<int>(type: "int", nullable: false),
                    CodeLeader = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.CodeEmployee);
                    table.ForeignKey(
                        name: "FK_Employees_Groups_CodeGroup",
                        column: x => x.CodeGroup,
                        principalTable: "Groups",
                        principalColumn: "CodeGroup",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CodeGroup",
                table: "Employees",
                column: "CodeGroup");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CodeLeader",
                table: "Employees",
                column: "CodeLeader");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_CodeDepartment",
                table: "Groups",
                column: "CodeDepartment");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
