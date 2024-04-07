using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Irrigation_Management.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Systems_SystemsSystem_Id",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_SystemsSystem_Id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "System_Id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SystemsSystem_Id",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "Achievements",
                columns: table => new
                {
                    Achievement_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Achievement_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Achievement_Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Achievement_Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievements", x => x.Achievement_Id);
                });

            migrationBuilder.CreateTable(
                name: "Scores",
                columns: table => new
                {
                    Score_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Success_Rate = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Water_Saved = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(5,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scores", x => x.Score_Id);
                });

            migrationBuilder.CreateTable(
                name: "Allocation_Achievements",
                columns: table => new
                {
                    Users_Id = table.Column<int>(type: "int", nullable: false),
                    Achievement_Id = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Game_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Stage = table.Column<int>(type: "int", nullable: true),
                    End_Score = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Users_Id = table.Column<int>(type: "int", nullable: false),
                    Score_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Game_Id);
                    table.ForeignKey(
                        name: "FK_Games_Scores_Score_Id",
                        column: x => x.Score_Id,
                        principalTable: "Scores",
                        principalColumn: "Score_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Games_Users_Users_Id",
                        column: x => x.Users_Id,
                        principalTable: "Users",
                        principalColumn: "Users_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Allocation_Systems",
                columns: table => new
                {
                    Game_Id = table.Column<int>(type: "int", nullable: false),
                    GamesGame_Id = table.Column<int>(type: "int", nullable: true),
                    System_Id = table.Column<int>(type: "int", nullable: false),
                    SystemsSystem_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Allocation_Systems_Games_GamesGame_Id",
                        column: x => x.GamesGame_Id,
                        principalTable: "Games",
                        principalColumn: "Game_Id");
                    table.ForeignKey(
                        name: "FK_Allocation_Systems_Systems_SystemsSystem_Id",
                        column: x => x.SystemsSystem_Id,
                        principalTable: "Systems",
                        principalColumn: "System_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Allocation_Achievements_Achievement_Id",
                table: "Allocation_Achievements",
                column: "Achievement_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Allocation_Achievements_Users_Id",
                table: "Allocation_Achievements",
                column: "Users_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Allocation_Systems_GamesGame_Id",
                table: "Allocation_Systems",
                column: "GamesGame_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Allocation_Systems_SystemsSystem_Id",
                table: "Allocation_Systems",
                column: "SystemsSystem_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Score_Id",
                table: "Games",
                column: "Score_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Users_Id",
                table: "Games",
                column: "Users_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allocation_Achievements");

            migrationBuilder.DropTable(
                name: "Allocation_Systems");

            migrationBuilder.DropTable(
                name: "Achievements");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Scores");

            migrationBuilder.AddColumn<int>(
                name: "System_Id",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SystemsSystem_Id",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_SystemsSystem_Id",
                table: "Users",
                column: "SystemsSystem_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Systems_SystemsSystem_Id",
                table: "Users",
                column: "SystemsSystem_Id",
                principalTable: "Systems",
                principalColumn: "System_Id");
        }
    }
}
