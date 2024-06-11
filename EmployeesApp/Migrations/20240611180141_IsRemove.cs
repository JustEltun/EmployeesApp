using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeesApp.Migrations
{
    /// <inheritdoc />
    public partial class IsRemove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRemove",
                table: "Employees",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRemove",
                table: "Employees");
        }
    }
}
