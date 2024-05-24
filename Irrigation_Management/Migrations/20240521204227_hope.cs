using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Irrigation_Management.Migrations
{
    /// <inheritdoc />
    public partial class hope : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Users",
                type: "nvarchar(69)",
                maxLength: 69,
                nullable: false,
                defaultValue: "Bogotá");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Users");
        }
    }
}
