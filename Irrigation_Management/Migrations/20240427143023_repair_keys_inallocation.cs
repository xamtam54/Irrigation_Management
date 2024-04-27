using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Irrigation_Management.Migrations
{
    /// <inheritdoc />
    public partial class repair_keys_inallocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Allocation_Systems_Id",
                table: "Allocation_Systems",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Allocation_Systems",
                table: "Allocation_Systems",
                column: "Allocation_Systems_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Allocation_Systems",
                table: "Allocation_Systems");

            migrationBuilder.DropColumn(
                name: "Allocation_Systems_Id",
                table: "Allocation_Systems");
        }
    }
}
