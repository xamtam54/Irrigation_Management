using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Irrigation_Management.Migrations
{
    /// <inheritdoc />
    public partial class Fourth_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Users_Users_Id",
                table: "Games");

            migrationBuilder.DropTable(
                name: "Allocation_Achievements");

            migrationBuilder.RenameColumn(
                name: "Users_Id",
                table: "Games",
                newName: "Achievement_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Games_Users_Id",
                table: "Games",
                newName: "IX_Games_Achievement_Id");

            migrationBuilder.AlterColumn<int>(
                name: "Game_Id",
                table: "Allocation_Systems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "User_Id",
                table: "Allocation_Systems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Users_Id",
                table: "Allocation_Systems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Allocation_Systems_Users_Id",
                table: "Allocation_Systems",
                column: "Users_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Allocation_Systems_Users_Users_Id",
                table: "Allocation_Systems",
                column: "Users_Id",
                principalTable: "Users",
                principalColumn: "Users_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Achievements_Achievement_Id",
                table: "Games",
                column: "Achievement_Id",
                principalTable: "Achievements",
                principalColumn: "Achievement_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allocation_Systems_Users_Users_Id",
                table: "Allocation_Systems");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Achievements_Achievement_Id",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Allocation_Systems_Users_Id",
                table: "Allocation_Systems");

            migrationBuilder.DropColumn(
                name: "User_Id",
                table: "Allocation_Systems");

            migrationBuilder.DropColumn(
                name: "Users_Id",
                table: "Allocation_Systems");

            migrationBuilder.RenameColumn(
                name: "Achievement_Id",
                table: "Games",
                newName: "Users_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Games_Achievement_Id",
                table: "Games",
                newName: "IX_Games_Users_Id");

            migrationBuilder.AlterColumn<int>(
                name: "Game_Id",
                table: "Allocation_Systems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Allocation_Achievements",
                columns: table => new
                {
                    Achievement_Id = table.Column<int>(type: "int", nullable: false),
                    Users_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Allocation_Achievements_Achievements_Achievement_Id",
                        column: x => x.Achievement_Id,
                        principalTable: "Achievements",
                        principalColumn: "Achievement_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Allocation_Achievements_Users_Users_Id",
                        column: x => x.Users_Id,
                        principalTable: "Users",
                        principalColumn: "Users_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Allocation_Achievements_Achievement_Id",
                table: "Allocation_Achievements",
                column: "Achievement_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Allocation_Achievements_Users_Id",
                table: "Allocation_Achievements",
                column: "Users_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Users_Users_Id",
                table: "Games",
                column: "Users_Id",
                principalTable: "Users",
                principalColumn: "Users_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
