using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Irrigation_Management.Migrations
{
    /// <inheritdoc />
    public partial class sixth_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allocation_Systems_Games_GamesGame_Id",
                table: "Allocation_Systems");

            migrationBuilder.DropForeignKey(
                name: "FK_Allocation_Systems_Systems_SystemsSystem_Id",
                table: "Allocation_Systems");

            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Planting_Areas_Planting_AreasArea_Id",
                table: "Devices");

            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Systems_SystemsSystem_Id",
                table: "Devices");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Achievements_Achievement_Id",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Scores_Score_Id",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Irrigation_Actuators_Devices_DevicesDevice_Id",
                table: "Irrigation_Actuators");

            migrationBuilder.DropForeignKey(
                name: "FK_Irrigation_Actuators_Irrigation_Actuators_Types_Irrigation_Actuators_TypesIrrigation_Actuators_Type_Id",
                table: "Irrigation_Actuators");

            migrationBuilder.DropForeignKey(
                name: "FK_Irrigation_Programs_Planting_Areas_Planting_AreasArea_Id",
                table: "Irrigation_Programs");

            migrationBuilder.DropForeignKey(
                name: "FK_Planting_Areas_Crop_Status_Crop_Status_Id",
                table: "Planting_Areas");

            migrationBuilder.DropForeignKey(
                name: "FK_Planting_Areas_Plants_PlantsPlant_Id",
                table: "Planting_Areas");

            migrationBuilder.DropForeignKey(
                name: "FK_Sensor_Data_Sensors_Sensor_TypeSensor_Id",
                table: "Sensor_Data");

            migrationBuilder.DropForeignKey(
                name: "FK_Sensors_Devices_DevicesDevice_Id",
                table: "Sensors");

            migrationBuilder.DropForeignKey(
                name: "FK_Sensors_Sensor_Types_Sensor_TypesSensor_Type_Id",
                table: "Sensors");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_User_Types_User_TypesUser_Type_Id",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Water_Managements_Devices_DevicesDevice_Id",
                table: "Water_Managements");

            migrationBuilder.DropForeignKey(
                name: "FK_Water_Managements_Water_Management_Types_Water_Management_TypesWater_Management_Type_Id",
                table: "Water_Managements");

            migrationBuilder.DropIndex(
                name: "IX_Planting_Areas_Crop_Status_Id",
                table: "Planting_Areas");

            migrationBuilder.DropIndex(
                name: "IX_Games_Achievement_Id",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_Score_Id",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "Water_Management_TypesWater_Management_Type_Id",
                table: "Water_Managements",
                newName: "Water_Management_Type_Id1");

            migrationBuilder.RenameColumn(
                name: "DevicesDevice_Id",
                table: "Water_Managements",
                newName: "Device_Id1");

            migrationBuilder.RenameIndex(
                name: "IX_Water_Managements_Water_Management_TypesWater_Management_Type_Id",
                table: "Water_Managements",
                newName: "IX_Water_Managements_Water_Management_Type_Id1");

            migrationBuilder.RenameIndex(
                name: "IX_Water_Managements_DevicesDevice_Id",
                table: "Water_Managements",
                newName: "IX_Water_Managements_Device_Id1");

            migrationBuilder.RenameColumn(
                name: "User_TypesUser_Type_Id",
                table: "Users",
                newName: "User_Type_Id1");

            migrationBuilder.RenameIndex(
                name: "IX_Users_User_TypesUser_Type_Id",
                table: "Users",
                newName: "IX_Users_User_Type_Id1");

            migrationBuilder.RenameColumn(
                name: "Sensor_TypesSensor_Type_Id",
                table: "Sensors",
                newName: "Sensor_Type_Id1");

            migrationBuilder.RenameColumn(
                name: "DevicesDevice_Id",
                table: "Sensors",
                newName: "Device_Id1");

            migrationBuilder.RenameIndex(
                name: "IX_Sensors_Sensor_TypesSensor_Type_Id",
                table: "Sensors",
                newName: "IX_Sensors_Sensor_Type_Id1");

            migrationBuilder.RenameIndex(
                name: "IX_Sensors_DevicesDevice_Id",
                table: "Sensors",
                newName: "IX_Sensors_Device_Id1");

            migrationBuilder.RenameColumn(
                name: "Sensor_TypeSensor_Id",
                table: "Sensor_Data",
                newName: "Sensor_Id1");

            migrationBuilder.RenameIndex(
                name: "IX_Sensor_Data_Sensor_TypeSensor_Id",
                table: "Sensor_Data",
                newName: "IX_Sensor_Data_Sensor_Id1");

            migrationBuilder.RenameColumn(
                name: "PlantsPlant_Id",
                table: "Planting_Areas",
                newName: "Plant_Id1");

            migrationBuilder.RenameIndex(
                name: "IX_Planting_Areas_PlantsPlant_Id",
                table: "Planting_Areas",
                newName: "IX_Planting_Areas_Plant_Id1");

            migrationBuilder.RenameColumn(
                name: "Planting_AreasArea_Id",
                table: "Irrigation_Programs",
                newName: "Planting_AreaArea_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Irrigation_Programs_Planting_AreasArea_Id",
                table: "Irrigation_Programs",
                newName: "IX_Irrigation_Programs_Planting_AreaArea_Id");

            migrationBuilder.RenameColumn(
                name: "Irrigation_Actuators_TypesIrrigation_Actuators_Type_Id",
                table: "Irrigation_Actuators",
                newName: "Irrigation_Actuators_Type_Id1");

            migrationBuilder.RenameColumn(
                name: "DevicesDevice_Id",
                table: "Irrigation_Actuators",
                newName: "Device_Id1");

            migrationBuilder.RenameIndex(
                name: "IX_Irrigation_Actuators_Irrigation_Actuators_TypesIrrigation_Actuators_Type_Id",
                table: "Irrigation_Actuators",
                newName: "IX_Irrigation_Actuators_Irrigation_Actuators_Type_Id1");

            migrationBuilder.RenameIndex(
                name: "IX_Irrigation_Actuators_DevicesDevice_Id",
                table: "Irrigation_Actuators",
                newName: "IX_Irrigation_Actuators_Device_Id1");

            migrationBuilder.RenameColumn(
                name: "SystemsSystem_Id",
                table: "Devices",
                newName: "System_Id1");

            migrationBuilder.RenameColumn(
                name: "Planting_AreasArea_Id",
                table: "Devices",
                newName: "Planting_AreaArea_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Devices_SystemsSystem_Id",
                table: "Devices",
                newName: "IX_Devices_System_Id1");

            migrationBuilder.RenameIndex(
                name: "IX_Devices_Planting_AreasArea_Id",
                table: "Devices",
                newName: "IX_Devices_Planting_AreaArea_Id");

            migrationBuilder.RenameColumn(
                name: "SystemsSystem_Id",
                table: "Allocation_Systems",
                newName: "System_Id1");

            migrationBuilder.RenameColumn(
                name: "GamesGame_Id",
                table: "Allocation_Systems",
                newName: "Game_Id1");

            migrationBuilder.RenameIndex(
                name: "IX_Allocation_Systems_SystemsSystem_Id",
                table: "Allocation_Systems",
                newName: "IX_Allocation_Systems_System_Id1");

            migrationBuilder.RenameIndex(
                name: "IX_Allocation_Systems_GamesGame_Id",
                table: "Allocation_Systems",
                newName: "IX_Allocation_Systems_Game_Id1");

            migrationBuilder.AddColumn<int>(
                name: "Crop_Status_Id1",
                table: "Planting_Areas",
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

            migrationBuilder.CreateIndex(
                name: "IX_Planting_Areas_Crop_Status_Id1",
                table: "Planting_Areas",
                column: "Crop_Status_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Achievement_Id1",
                table: "Games",
                column: "Achievement_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Score_Id1",
                table: "Games",
                column: "Score_Id1");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allocation_Systems_Games_Game_Id1",
                table: "Allocation_Systems");

            migrationBuilder.DropForeignKey(
                name: "FK_Allocation_Systems_Systems_System_Id1",
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
                name: "IX_Planting_Areas_Crop_Status_Id1",
                table: "Planting_Areas");

            migrationBuilder.DropIndex(
                name: "IX_Games_Achievement_Id1",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_Score_Id1",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Crop_Status_Id1",
                table: "Planting_Areas");

            migrationBuilder.DropColumn(
                name: "Achievement_Id1",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Score_Id1",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "Water_Management_Type_Id1",
                table: "Water_Managements",
                newName: "Water_Management_TypesWater_Management_Type_Id");

            migrationBuilder.RenameColumn(
                name: "Device_Id1",
                table: "Water_Managements",
                newName: "DevicesDevice_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Water_Managements_Water_Management_Type_Id1",
                table: "Water_Managements",
                newName: "IX_Water_Managements_Water_Management_TypesWater_Management_Type_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Water_Managements_Device_Id1",
                table: "Water_Managements",
                newName: "IX_Water_Managements_DevicesDevice_Id");

            migrationBuilder.RenameColumn(
                name: "User_Type_Id1",
                table: "Users",
                newName: "User_TypesUser_Type_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Users_User_Type_Id1",
                table: "Users",
                newName: "IX_Users_User_TypesUser_Type_Id");

            migrationBuilder.RenameColumn(
                name: "Sensor_Type_Id1",
                table: "Sensors",
                newName: "Sensor_TypesSensor_Type_Id");

            migrationBuilder.RenameColumn(
                name: "Device_Id1",
                table: "Sensors",
                newName: "DevicesDevice_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Sensors_Sensor_Type_Id1",
                table: "Sensors",
                newName: "IX_Sensors_Sensor_TypesSensor_Type_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Sensors_Device_Id1",
                table: "Sensors",
                newName: "IX_Sensors_DevicesDevice_Id");

            migrationBuilder.RenameColumn(
                name: "Sensor_Id1",
                table: "Sensor_Data",
                newName: "Sensor_TypeSensor_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Sensor_Data_Sensor_Id1",
                table: "Sensor_Data",
                newName: "IX_Sensor_Data_Sensor_TypeSensor_Id");

            migrationBuilder.RenameColumn(
                name: "Plant_Id1",
                table: "Planting_Areas",
                newName: "PlantsPlant_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Planting_Areas_Plant_Id1",
                table: "Planting_Areas",
                newName: "IX_Planting_Areas_PlantsPlant_Id");

            migrationBuilder.RenameColumn(
                name: "Planting_AreaArea_Id",
                table: "Irrigation_Programs",
                newName: "Planting_AreasArea_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Irrigation_Programs_Planting_AreaArea_Id",
                table: "Irrigation_Programs",
                newName: "IX_Irrigation_Programs_Planting_AreasArea_Id");

            migrationBuilder.RenameColumn(
                name: "Irrigation_Actuators_Type_Id1",
                table: "Irrigation_Actuators",
                newName: "Irrigation_Actuators_TypesIrrigation_Actuators_Type_Id");

            migrationBuilder.RenameColumn(
                name: "Device_Id1",
                table: "Irrigation_Actuators",
                newName: "DevicesDevice_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Irrigation_Actuators_Irrigation_Actuators_Type_Id1",
                table: "Irrigation_Actuators",
                newName: "IX_Irrigation_Actuators_Irrigation_Actuators_TypesIrrigation_Actuators_Type_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Irrigation_Actuators_Device_Id1",
                table: "Irrigation_Actuators",
                newName: "IX_Irrigation_Actuators_DevicesDevice_Id");

            migrationBuilder.RenameColumn(
                name: "System_Id1",
                table: "Devices",
                newName: "SystemsSystem_Id");

            migrationBuilder.RenameColumn(
                name: "Planting_AreaArea_Id",
                table: "Devices",
                newName: "Planting_AreasArea_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Devices_System_Id1",
                table: "Devices",
                newName: "IX_Devices_SystemsSystem_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Devices_Planting_AreaArea_Id",
                table: "Devices",
                newName: "IX_Devices_Planting_AreasArea_Id");

            migrationBuilder.RenameColumn(
                name: "System_Id1",
                table: "Allocation_Systems",
                newName: "SystemsSystem_Id");

            migrationBuilder.RenameColumn(
                name: "Game_Id1",
                table: "Allocation_Systems",
                newName: "GamesGame_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Allocation_Systems_System_Id1",
                table: "Allocation_Systems",
                newName: "IX_Allocation_Systems_SystemsSystem_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Allocation_Systems_Game_Id1",
                table: "Allocation_Systems",
                newName: "IX_Allocation_Systems_GamesGame_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Planting_Areas_Crop_Status_Id",
                table: "Planting_Areas",
                column: "Crop_Status_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Achievement_Id",
                table: "Games",
                column: "Achievement_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Score_Id",
                table: "Games",
                column: "Score_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Allocation_Systems_Games_GamesGame_Id",
                table: "Allocation_Systems",
                column: "GamesGame_Id",
                principalTable: "Games",
                principalColumn: "Game_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Allocation_Systems_Systems_SystemsSystem_Id",
                table: "Allocation_Systems",
                column: "SystemsSystem_Id",
                principalTable: "Systems",
                principalColumn: "System_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Planting_Areas_Planting_AreasArea_Id",
                table: "Devices",
                column: "Planting_AreasArea_Id",
                principalTable: "Planting_Areas",
                principalColumn: "Area_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Systems_SystemsSystem_Id",
                table: "Devices",
                column: "SystemsSystem_Id",
                principalTable: "Systems",
                principalColumn: "System_Id");

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
                name: "FK_Irrigation_Actuators_Devices_DevicesDevice_Id",
                table: "Irrigation_Actuators",
                column: "DevicesDevice_Id",
                principalTable: "Devices",
                principalColumn: "Device_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Irrigation_Actuators_Irrigation_Actuators_Types_Irrigation_Actuators_TypesIrrigation_Actuators_Type_Id",
                table: "Irrigation_Actuators",
                column: "Irrigation_Actuators_TypesIrrigation_Actuators_Type_Id",
                principalTable: "Irrigation_Actuators_Types",
                principalColumn: "Irrigation_Actuators_Type_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Irrigation_Programs_Planting_Areas_Planting_AreasArea_Id",
                table: "Irrigation_Programs",
                column: "Planting_AreasArea_Id",
                principalTable: "Planting_Areas",
                principalColumn: "Area_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Planting_Areas_Crop_Status_Crop_Status_Id",
                table: "Planting_Areas",
                column: "Crop_Status_Id",
                principalTable: "Crop_Status",
                principalColumn: "Crop_Status_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Planting_Areas_Plants_PlantsPlant_Id",
                table: "Planting_Areas",
                column: "PlantsPlant_Id",
                principalTable: "Plants",
                principalColumn: "Plant_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sensor_Data_Sensors_Sensor_TypeSensor_Id",
                table: "Sensor_Data",
                column: "Sensor_TypeSensor_Id",
                principalTable: "Sensors",
                principalColumn: "Sensor_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sensors_Devices_DevicesDevice_Id",
                table: "Sensors",
                column: "DevicesDevice_Id",
                principalTable: "Devices",
                principalColumn: "Device_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sensors_Sensor_Types_Sensor_TypesSensor_Type_Id",
                table: "Sensors",
                column: "Sensor_TypesSensor_Type_Id",
                principalTable: "Sensor_Types",
                principalColumn: "Sensor_Type_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_User_Types_User_TypesUser_Type_Id",
                table: "Users",
                column: "User_TypesUser_Type_Id",
                principalTable: "User_Types",
                principalColumn: "User_Type_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Water_Managements_Devices_DevicesDevice_Id",
                table: "Water_Managements",
                column: "DevicesDevice_Id",
                principalTable: "Devices",
                principalColumn: "Device_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Water_Managements_Water_Management_Types_Water_Management_TypesWater_Management_Type_Id",
                table: "Water_Managements",
                column: "Water_Management_TypesWater_Management_Type_Id",
                principalTable: "Water_Management_Types",
                principalColumn: "Water_Management_Type_Id");
        }
    }
}
