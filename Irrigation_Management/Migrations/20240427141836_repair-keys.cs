using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Irrigation_Management.Migrations
{
    /// <inheritdoc />
    public partial class repairkeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allocation_Systems_Games_Game_Id1",
                table: "Allocation_Systems");

            migrationBuilder.DropForeignKey(
                name: "FK_Allocation_Systems_Systems_System_Id1",
                table: "Allocation_Systems");

            migrationBuilder.DropForeignKey(
                name: "FK_Allocation_Systems_Users_Users_Id",
                table: "Allocation_Systems");

            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Planting_Areas_Planting_AreaArea_Id",
                table: "Devices");

            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Systems_System_Id1",
                table: "Devices");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Achievements_Achievement_Id1",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Scores_Score_Id1",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Irrigation_Actuators_Devices_Device_Id1",
                table: "Irrigation_Actuators");

            migrationBuilder.DropForeignKey(
                name: "FK_Irrigation_Actuators_Irrigation_Actuators_Types_Irrigation_Actuators_Type_Id1",
                table: "Irrigation_Actuators");

            migrationBuilder.DropForeignKey(
                name: "FK_Irrigation_Programs_Planting_Areas_Planting_AreaArea_Id",
                table: "Irrigation_Programs");

            migrationBuilder.DropForeignKey(
                name: "FK_Planting_Areas_Crop_Status_Crop_Status_Id1",
                table: "Planting_Areas");

            migrationBuilder.DropForeignKey(
                name: "FK_Planting_Areas_Plants_Plant_Id1",
                table: "Planting_Areas");

            migrationBuilder.DropForeignKey(
                name: "FK_Sensor_Data_Sensors_Sensor_Id1",
                table: "Sensor_Data");

            migrationBuilder.DropForeignKey(
                name: "FK_Sensors_Devices_Device_Id1",
                table: "Sensors");

            migrationBuilder.DropForeignKey(
                name: "FK_Sensors_Sensor_Types_Sensor_Type_Id1",
                table: "Sensors");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_User_Types_User_Type_Id1",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Water_Managements_Devices_Device_Id1",
                table: "Water_Managements");

            migrationBuilder.DropForeignKey(
                name: "FK_Water_Managements_Water_Management_Types_Water_Management_Type_Id1",
                table: "Water_Managements");

            migrationBuilder.DropIndex(
                name: "IX_Water_Managements_Device_Id1",
                table: "Water_Managements");

            migrationBuilder.DropIndex(
                name: "IX_Water_Managements_Water_Management_Type_Id1",
                table: "Water_Managements");

            migrationBuilder.DropIndex(
                name: "IX_Users_User_Type_Id1",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Sensors_Device_Id1",
                table: "Sensors");

            migrationBuilder.DropIndex(
                name: "IX_Sensors_Sensor_Type_Id1",
                table: "Sensors");

            migrationBuilder.DropIndex(
                name: "IX_Sensor_Data_Sensor_Id1",
                table: "Sensor_Data");

            migrationBuilder.DropIndex(
                name: "IX_Planting_Areas_Crop_Status_Id1",
                table: "Planting_Areas");

            migrationBuilder.DropIndex(
                name: "IX_Planting_Areas_Plant_Id1",
                table: "Planting_Areas");

            migrationBuilder.DropIndex(
                name: "IX_Irrigation_Programs_Planting_AreaArea_Id",
                table: "Irrigation_Programs");

            migrationBuilder.DropIndex(
                name: "IX_Irrigation_Actuators_Device_Id1",
                table: "Irrigation_Actuators");

            migrationBuilder.DropIndex(
                name: "IX_Irrigation_Actuators_Irrigation_Actuators_Type_Id1",
                table: "Irrigation_Actuators");

            migrationBuilder.DropIndex(
                name: "IX_Games_Achievement_Id1",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_Score_Id1",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Devices_Planting_AreaArea_Id",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Devices_System_Id1",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Allocation_Systems_Game_Id1",
                table: "Allocation_Systems");

            migrationBuilder.DropIndex(
                name: "IX_Allocation_Systems_System_Id1",
                table: "Allocation_Systems");

            migrationBuilder.DropIndex(
                name: "IX_Allocation_Systems_Users_Id",
                table: "Allocation_Systems");

            migrationBuilder.DropColumn(
                name: "Device_Id1",
                table: "Water_Managements");

            migrationBuilder.DropColumn(
                name: "Water_Management_Type_Id1",
                table: "Water_Managements");

            migrationBuilder.DropColumn(
                name: "User_Type_Id1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Device_Id1",
                table: "Sensors");

            migrationBuilder.DropColumn(
                name: "Sensor_Type_Id1",
                table: "Sensors");

            migrationBuilder.DropColumn(
                name: "Sensor_Id1",
                table: "Sensor_Data");

            migrationBuilder.DropColumn(
                name: "Crop_Status_Id1",
                table: "Planting_Areas");

            migrationBuilder.DropColumn(
                name: "Plant_Id1",
                table: "Planting_Areas");

            migrationBuilder.DropColumn(
                name: "Planting_AreaArea_Id",
                table: "Irrigation_Programs");

            migrationBuilder.DropColumn(
                name: "Device_Id1",
                table: "Irrigation_Actuators");

            migrationBuilder.DropColumn(
                name: "Irrigation_Actuators_Type_Id1",
                table: "Irrigation_Actuators");

            migrationBuilder.DropColumn(
                name: "Achievement_Id1",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Score_Id1",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Planting_AreaArea_Id",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "System_Id1",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "Game_Id1",
                table: "Allocation_Systems");

            migrationBuilder.DropColumn(
                name: "System_Id1",
                table: "Allocation_Systems");

            migrationBuilder.DropColumn(
                name: "Users_Id",
                table: "Allocation_Systems");

            migrationBuilder.CreateIndex(
                name: "IX_Water_Managements_Device_Id",
                table: "Water_Managements",
                column: "Device_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Water_Managements_Water_Management_Type_Id",
                table: "Water_Managements",
                column: "Water_Management_Type_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_User_Type_Id",
                table: "Users",
                column: "User_Type_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Sensors_Device_Id",
                table: "Sensors",
                column: "Device_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Sensors_Sensor_Type_Id",
                table: "Sensors",
                column: "Sensor_Type_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Sensor_Data_Sensor_Id",
                table: "Sensor_Data",
                column: "Sensor_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Planting_Areas_Crop_Status_Id",
                table: "Planting_Areas",
                column: "Crop_Status_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Planting_Areas_Plant_Id",
                table: "Planting_Areas",
                column: "Plant_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Irrigation_Programs_Area_Id",
                table: "Irrigation_Programs",
                column: "Area_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Irrigation_Actuators_Device_Id",
                table: "Irrigation_Actuators",
                column: "Device_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Irrigation_Actuators_Irrigation_Actuators_Type_Id",
                table: "Irrigation_Actuators",
                column: "Irrigation_Actuators_Type_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Achievement_Id",
                table: "Games",
                column: "Achievement_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Score_Id",
                table: "Games",
                column: "Score_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_Area_Id",
                table: "Devices",
                column: "Area_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_System_Id",
                table: "Devices",
                column: "System_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Allocation_Systems_Game_Id",
                table: "Allocation_Systems",
                column: "Game_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Allocation_Systems_System_Id",
                table: "Allocation_Systems",
                column: "System_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Allocation_Systems_User_Id",
                table: "Allocation_Systems",
                column: "User_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Allocation_Systems_Games_Game_Id",
                table: "Allocation_Systems",
                column: "Game_Id",
                principalTable: "Games",
                principalColumn: "Game_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Allocation_Systems_Systems_System_Id",
                table: "Allocation_Systems",
                column: "System_Id",
                principalTable: "Systems",
                principalColumn: "System_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Allocation_Systems_Users_User_Id",
                table: "Allocation_Systems",
                column: "User_Id",
                principalTable: "Users",
                principalColumn: "Users_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Planting_Areas_Area_Id",
                table: "Devices",
                column: "Area_Id",
                principalTable: "Planting_Areas",
                principalColumn: "Area_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Systems_System_Id",
                table: "Devices",
                column: "System_Id",
                principalTable: "Systems",
                principalColumn: "System_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Achievements_Achievement_Id",
                table: "Games",
                column: "Achievement_Id",
                principalTable: "Achievements",
                principalColumn: "Achievement_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Scores_Score_Id",
                table: "Games",
                column: "Score_Id",
                principalTable: "Scores",
                principalColumn: "Score_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Irrigation_Actuators_Devices_Device_Id",
                table: "Irrigation_Actuators",
                column: "Device_Id",
                principalTable: "Devices",
                principalColumn: "Device_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Irrigation_Actuators_Irrigation_Actuators_Types_Irrigation_Actuators_Type_Id",
                table: "Irrigation_Actuators",
                column: "Irrigation_Actuators_Type_Id",
                principalTable: "Irrigation_Actuators_Types",
                principalColumn: "Irrigation_Actuators_Type_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Irrigation_Programs_Planting_Areas_Area_Id",
                table: "Irrigation_Programs",
                column: "Area_Id",
                principalTable: "Planting_Areas",
                principalColumn: "Area_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Planting_Areas_Crop_Status_Crop_Status_Id",
                table: "Planting_Areas",
                column: "Crop_Status_Id",
                principalTable: "Crop_Status",
                principalColumn: "Crop_Status_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Planting_Areas_Plants_Plant_Id",
                table: "Planting_Areas",
                column: "Plant_Id",
                principalTable: "Plants",
                principalColumn: "Plant_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sensor_Data_Sensors_Sensor_Id",
                table: "Sensor_Data",
                column: "Sensor_Id",
                principalTable: "Sensors",
                principalColumn: "Sensor_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sensors_Devices_Device_Id",
                table: "Sensors",
                column: "Device_Id",
                principalTable: "Devices",
                principalColumn: "Device_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sensors_Sensor_Types_Sensor_Type_Id",
                table: "Sensors",
                column: "Sensor_Type_Id",
                principalTable: "Sensor_Types",
                principalColumn: "Sensor_Type_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_User_Types_User_Type_Id",
                table: "Users",
                column: "User_Type_Id",
                principalTable: "User_Types",
                principalColumn: "User_Type_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Water_Managements_Devices_Device_Id",
                table: "Water_Managements",
                column: "Device_Id",
                principalTable: "Devices",
                principalColumn: "Device_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Water_Managements_Water_Management_Types_Water_Management_Type_Id",
                table: "Water_Managements",
                column: "Water_Management_Type_Id",
                principalTable: "Water_Management_Types",
                principalColumn: "Water_Management_Type_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allocation_Systems_Games_Game_Id",
                table: "Allocation_Systems");

            migrationBuilder.DropForeignKey(
                name: "FK_Allocation_Systems_Systems_System_Id",
                table: "Allocation_Systems");

            migrationBuilder.DropForeignKey(
                name: "FK_Allocation_Systems_Users_User_Id",
                table: "Allocation_Systems");

            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Planting_Areas_Area_Id",
                table: "Devices");

            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Systems_System_Id",
                table: "Devices");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Achievements_Achievement_Id",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Scores_Score_Id",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Irrigation_Actuators_Devices_Device_Id",
                table: "Irrigation_Actuators");

            migrationBuilder.DropForeignKey(
                name: "FK_Irrigation_Actuators_Irrigation_Actuators_Types_Irrigation_Actuators_Type_Id",
                table: "Irrigation_Actuators");

            migrationBuilder.DropForeignKey(
                name: "FK_Irrigation_Programs_Planting_Areas_Area_Id",
                table: "Irrigation_Programs");

            migrationBuilder.DropForeignKey(
                name: "FK_Planting_Areas_Crop_Status_Crop_Status_Id",
                table: "Planting_Areas");

            migrationBuilder.DropForeignKey(
                name: "FK_Planting_Areas_Plants_Plant_Id",
                table: "Planting_Areas");

            migrationBuilder.DropForeignKey(
                name: "FK_Sensor_Data_Sensors_Sensor_Id",
                table: "Sensor_Data");

            migrationBuilder.DropForeignKey(
                name: "FK_Sensors_Devices_Device_Id",
                table: "Sensors");

            migrationBuilder.DropForeignKey(
                name: "FK_Sensors_Sensor_Types_Sensor_Type_Id",
                table: "Sensors");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_User_Types_User_Type_Id",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Water_Managements_Devices_Device_Id",
                table: "Water_Managements");

            migrationBuilder.DropForeignKey(
                name: "FK_Water_Managements_Water_Management_Types_Water_Management_Type_Id",
                table: "Water_Managements");

            migrationBuilder.DropIndex(
                name: "IX_Water_Managements_Device_Id",
                table: "Water_Managements");

            migrationBuilder.DropIndex(
                name: "IX_Water_Managements_Water_Management_Type_Id",
                table: "Water_Managements");

            migrationBuilder.DropIndex(
                name: "IX_Users_User_Type_Id",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Sensors_Device_Id",
                table: "Sensors");

            migrationBuilder.DropIndex(
                name: "IX_Sensors_Sensor_Type_Id",
                table: "Sensors");

            migrationBuilder.DropIndex(
                name: "IX_Sensor_Data_Sensor_Id",
                table: "Sensor_Data");

            migrationBuilder.DropIndex(
                name: "IX_Planting_Areas_Crop_Status_Id",
                table: "Planting_Areas");

            migrationBuilder.DropIndex(
                name: "IX_Planting_Areas_Plant_Id",
                table: "Planting_Areas");

            migrationBuilder.DropIndex(
                name: "IX_Irrigation_Programs_Area_Id",
                table: "Irrigation_Programs");

            migrationBuilder.DropIndex(
                name: "IX_Irrigation_Actuators_Device_Id",
                table: "Irrigation_Actuators");

            migrationBuilder.DropIndex(
                name: "IX_Irrigation_Actuators_Irrigation_Actuators_Type_Id",
                table: "Irrigation_Actuators");

            migrationBuilder.DropIndex(
                name: "IX_Games_Achievement_Id",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_Score_Id",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Devices_Area_Id",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Devices_System_Id",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Allocation_Systems_Game_Id",
                table: "Allocation_Systems");

            migrationBuilder.DropIndex(
                name: "IX_Allocation_Systems_System_Id",
                table: "Allocation_Systems");

            migrationBuilder.DropIndex(
                name: "IX_Allocation_Systems_User_Id",
                table: "Allocation_Systems");

            migrationBuilder.AddColumn<int>(
                name: "Device_Id1",
                table: "Water_Managements",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Water_Management_Type_Id1",
                table: "Water_Managements",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "User_Type_Id1",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Device_Id1",
                table: "Sensors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sensor_Type_Id1",
                table: "Sensors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sensor_Id1",
                table: "Sensor_Data",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Crop_Status_Id1",
                table: "Planting_Areas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Plant_Id1",
                table: "Planting_Areas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Planting_AreaArea_Id",
                table: "Irrigation_Programs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Device_Id1",
                table: "Irrigation_Actuators",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Irrigation_Actuators_Type_Id1",
                table: "Irrigation_Actuators",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Achievement_Id1",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Score_Id1",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Planting_AreaArea_Id",
                table: "Devices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "System_Id1",
                table: "Devices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Game_Id1",
                table: "Allocation_Systems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "System_Id1",
                table: "Allocation_Systems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Users_Id",
                table: "Allocation_Systems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Water_Managements_Device_Id1",
                table: "Water_Managements",
                column: "Device_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Water_Managements_Water_Management_Type_Id1",
                table: "Water_Managements",
                column: "Water_Management_Type_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Users_User_Type_Id1",
                table: "Users",
                column: "User_Type_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Sensors_Device_Id1",
                table: "Sensors",
                column: "Device_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Sensors_Sensor_Type_Id1",
                table: "Sensors",
                column: "Sensor_Type_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Sensor_Data_Sensor_Id1",
                table: "Sensor_Data",
                column: "Sensor_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Planting_Areas_Crop_Status_Id1",
                table: "Planting_Areas",
                column: "Crop_Status_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Planting_Areas_Plant_Id1",
                table: "Planting_Areas",
                column: "Plant_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Irrigation_Programs_Planting_AreaArea_Id",
                table: "Irrigation_Programs",
                column: "Planting_AreaArea_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Irrigation_Actuators_Device_Id1",
                table: "Irrigation_Actuators",
                column: "Device_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Irrigation_Actuators_Irrigation_Actuators_Type_Id1",
                table: "Irrigation_Actuators",
                column: "Irrigation_Actuators_Type_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Achievement_Id1",
                table: "Games",
                column: "Achievement_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Score_Id1",
                table: "Games",
                column: "Score_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_Planting_AreaArea_Id",
                table: "Devices",
                column: "Planting_AreaArea_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_System_Id1",
                table: "Devices",
                column: "System_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Allocation_Systems_Game_Id1",
                table: "Allocation_Systems",
                column: "Game_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Allocation_Systems_System_Id1",
                table: "Allocation_Systems",
                column: "System_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Allocation_Systems_Users_Id",
                table: "Allocation_Systems",
                column: "Users_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Allocation_Systems_Games_Game_Id1",
                table: "Allocation_Systems",
                column: "Game_Id1",
                principalTable: "Games",
                principalColumn: "Game_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Allocation_Systems_Systems_System_Id1",
                table: "Allocation_Systems",
                column: "System_Id1",
                principalTable: "Systems",
                principalColumn: "System_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Allocation_Systems_Users_Users_Id",
                table: "Allocation_Systems",
                column: "Users_Id",
                principalTable: "Users",
                principalColumn: "Users_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Planting_Areas_Planting_AreaArea_Id",
                table: "Devices",
                column: "Planting_AreaArea_Id",
                principalTable: "Planting_Areas",
                principalColumn: "Area_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Systems_System_Id1",
                table: "Devices",
                column: "System_Id1",
                principalTable: "Systems",
                principalColumn: "System_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Achievements_Achievement_Id1",
                table: "Games",
                column: "Achievement_Id1",
                principalTable: "Achievements",
                principalColumn: "Achievement_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Scores_Score_Id1",
                table: "Games",
                column: "Score_Id1",
                principalTable: "Scores",
                principalColumn: "Score_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Irrigation_Actuators_Devices_Device_Id1",
                table: "Irrigation_Actuators",
                column: "Device_Id1",
                principalTable: "Devices",
                principalColumn: "Device_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Irrigation_Actuators_Irrigation_Actuators_Types_Irrigation_Actuators_Type_Id1",
                table: "Irrigation_Actuators",
                column: "Irrigation_Actuators_Type_Id1",
                principalTable: "Irrigation_Actuators_Types",
                principalColumn: "Irrigation_Actuators_Type_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Irrigation_Programs_Planting_Areas_Planting_AreaArea_Id",
                table: "Irrigation_Programs",
                column: "Planting_AreaArea_Id",
                principalTable: "Planting_Areas",
                principalColumn: "Area_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Planting_Areas_Crop_Status_Crop_Status_Id1",
                table: "Planting_Areas",
                column: "Crop_Status_Id1",
                principalTable: "Crop_Status",
                principalColumn: "Crop_Status_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Planting_Areas_Plants_Plant_Id1",
                table: "Planting_Areas",
                column: "Plant_Id1",
                principalTable: "Plants",
                principalColumn: "Plant_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sensor_Data_Sensors_Sensor_Id1",
                table: "Sensor_Data",
                column: "Sensor_Id1",
                principalTable: "Sensors",
                principalColumn: "Sensor_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sensors_Devices_Device_Id1",
                table: "Sensors",
                column: "Device_Id1",
                principalTable: "Devices",
                principalColumn: "Device_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sensors_Sensor_Types_Sensor_Type_Id1",
                table: "Sensors",
                column: "Sensor_Type_Id1",
                principalTable: "Sensor_Types",
                principalColumn: "Sensor_Type_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_User_Types_User_Type_Id1",
                table: "Users",
                column: "User_Type_Id1",
                principalTable: "User_Types",
                principalColumn: "User_Type_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Water_Managements_Devices_Device_Id1",
                table: "Water_Managements",
                column: "Device_Id1",
                principalTable: "Devices",
                principalColumn: "Device_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Water_Managements_Water_Management_Types_Water_Management_Type_Id1",
                table: "Water_Managements",
                column: "Water_Management_Type_Id1",
                principalTable: "Water_Management_Types",
                principalColumn: "Water_Management_Type_Id");
        }
    }
}
