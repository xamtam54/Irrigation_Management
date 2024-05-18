using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Irrigation_Management.Migrations
{
    /// <inheritdoc />
    public partial class end : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allocation_Systems_Systems_System_Id",
                table: "Allocation_Systems");

            migrationBuilder.AddColumn<string>(
                name: "Area_Name",
                table: "Planting_Areas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "System_Id",
                table: "Allocation_Systems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Allocation_Systems_Systems_System_Id",
                table: "Allocation_Systems",
                column: "System_Id",
                principalTable: "Systems",
                principalColumn: "System_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allocation_Systems_Systems_System_Id",
                table: "Allocation_Systems");

            migrationBuilder.DropColumn(
                name: "Area_Name",
                table: "Planting_Areas");

            migrationBuilder.AlterColumn<int>(
                name: "System_Id",
                table: "Allocation_Systems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Allocation_Systems_Systems_System_Id",
                table: "Allocation_Systems",
                column: "System_Id",
                principalTable: "Systems",
                principalColumn: "System_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
