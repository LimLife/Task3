using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task031023.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeLatNameIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_Gender",
                table: "Employees");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Gender_LastName",
                table: "Employees",
                columns: new[] { "Gender", "LastName" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_Gender_LastName",
                table: "Employees");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Gender",
                table: "Employees",
                column: "Gender");
        }
    }
}
