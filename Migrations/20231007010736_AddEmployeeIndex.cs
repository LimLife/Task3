using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task031023.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Employees_Gender",
                table: "Employees",
                column: "Gender");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_Gender",
                table: "Employees");
        }
    }
}
