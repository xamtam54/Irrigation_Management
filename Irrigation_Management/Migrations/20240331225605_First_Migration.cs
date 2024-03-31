using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Irrigation_Management.Migrations
{
    /// <inheritdoc />
    public partial class First_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crop_Status",
                columns: table => new
                {
                    Crop_Status_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Crop_Status_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Production_Percentage = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crop_Status", x => x.Crop_Status_Id);
                });

            migrationBuilder.CreateTable(
                name: "Irrigation_Actuators_Types",
                columns: table => new
                {
                    Irrigation_Actuators_Type_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Irrigation_Actuators_Types", x => x.Irrigation_Actuators_Type_Id);
                });

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    Plant_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Plant_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Specie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Min_PH = table.Column<float>(type: "real", nullable: false),
                    Max_PH = table.Column<float>(type: "real", nullable: false),
                    Requirement_Liters = table.Column<float>(type: "real", nullable: false),
                    Planting_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.Plant_Id);
                });

            migrationBuilder.CreateTable(
                name: "Sensor_Types",
                columns: table => new
                {
                    Sensor_Type_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sensor_Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Measure_Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensor_Types", x => x.Sensor_Type_Id);
                });

            migrationBuilder.CreateTable(
                name: "Systems",
                columns: table => new
                {
                    System_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Systems_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Systems", x => x.System_Id);
                });

            migrationBuilder.CreateTable(
                name: "User_Types",
                columns: table => new
                {
                    User_Type_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Type_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Types", x => x.User_Type_Id);
                });

            migrationBuilder.CreateTable(
                name: "Water_Management_Types",
                columns: table => new
                {
                    Water_Management_Type_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Material = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Water_Management_Types", x => x.Water_Management_Type_Id);
                });

            migrationBuilder.CreateTable(
                name: "Planting_Areas",
                columns: table => new
                {
                    Area_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Crop_Status_Id = table.Column<int>(type: "int", nullable: false),
                    Plant_Id = table.Column<int>(type: "int", nullable: false),
                    PlantsPlant_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planting_Areas", x => x.Area_Id);
                    table.ForeignKey(
                        name: "FK_Planting_Areas_Crop_Status_Crop_Status_Id",
                        column: x => x.Crop_Status_Id,
                        principalTable: "Crop_Status",
                        principalColumn: "Crop_Status_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Planting_Areas_Plants_PlantsPlant_Id",
                        column: x => x.PlantsPlant_Id,
                        principalTable: "Plants",
                        principalColumn: "Plant_Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Users_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Names = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Surnames = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Registration_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Is_Active = table.Column<int>(type: "int", nullable: false),
                    System_Id = table.Column<int>(type: "int", nullable: false),
                    SystemsSystem_Id = table.Column<int>(type: "int", nullable: true),
                    User_Type_Id = table.Column<int>(type: "int", nullable: false),
                    User_TypesUser_Type_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Users_Id);
                    table.ForeignKey(
                        name: "FK_Users_Systems_SystemsSystem_Id",
                        column: x => x.SystemsSystem_Id,
                        principalTable: "Systems",
                        principalColumn: "System_Id");
                    table.ForeignKey(
                        name: "FK_Users_User_Types_User_TypesUser_Type_Id",
                        column: x => x.User_TypesUser_Type_Id,
                        principalTable: "User_Types",
                        principalColumn: "User_Type_Id");
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Device_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Device_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Device_Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Device_Enabled = table.Column<int>(type: "int", nullable: false),
                    System_Id = table.Column<int>(type: "int", nullable: false),
                    SystemsSystem_Id = table.Column<int>(type: "int", nullable: true),
                    Area_Id = table.Column<int>(type: "int", nullable: true),
                    Planting_AreasArea_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Device_Id);
                    table.ForeignKey(
                        name: "FK_Devices_Planting_Areas_Planting_AreasArea_Id",
                        column: x => x.Planting_AreasArea_Id,
                        principalTable: "Planting_Areas",
                        principalColumn: "Area_Id");
                    table.ForeignKey(
                        name: "FK_Devices_Systems_SystemsSystem_Id",
                        column: x => x.SystemsSystem_Id,
                        principalTable: "Systems",
                        principalColumn: "System_Id");
                });

            migrationBuilder.CreateTable(
                name: "Irrigation_Programs",
                columns: table => new
                {
                    Irrigation_Program_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start_Hour = table.Column<TimeOnly>(type: "time", nullable: false),
                    End_Hour = table.Column<TimeOnly>(type: "time", nullable: false),
                    Irrigations_Per_Week = table.Column<int>(type: "int", nullable: false),
                    Area_Id = table.Column<int>(type: "int", nullable: false),
                    Planting_AreasArea_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Irrigation_Programs", x => x.Irrigation_Program_Id);
                    table.ForeignKey(
                        name: "FK_Irrigation_Programs_Planting_Areas_Planting_AreasArea_Id",
                        column: x => x.Planting_AreasArea_Id,
                        principalTable: "Planting_Areas",
                        principalColumn: "Area_Id");
                });

            migrationBuilder.CreateTable(
                name: "Irrigation_Actuators",
                columns: table => new
                {
                    Irrigation_Actuator_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Device_Id = table.Column<int>(type: "int", nullable: false),
                    DevicesDevice_Id = table.Column<int>(type: "int", nullable: true),
                    Irrigation_Actuators_Type_Id = table.Column<int>(type: "int", nullable: false),
                    Irrigation_Actuators_TypesIrrigation_Actuators_Type_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Irrigation_Actuators", x => x.Irrigation_Actuator_Id);
                    table.ForeignKey(
                        name: "FK_Irrigation_Actuators_Devices_DevicesDevice_Id",
                        column: x => x.DevicesDevice_Id,
                        principalTable: "Devices",
                        principalColumn: "Device_Id");
                    table.ForeignKey(
                        name: "FK_Irrigation_Actuators_Irrigation_Actuators_Types_Irrigation_Actuators_TypesIrrigation_Actuators_Type_Id",
                        column: x => x.Irrigation_Actuators_TypesIrrigation_Actuators_Type_Id,
                        principalTable: "Irrigation_Actuators_Types",
                        principalColumn: "Irrigation_Actuators_Type_Id");
                });

            migrationBuilder.CreateTable(
                name: "Sensors",
                columns: table => new
                {
                    Sensor_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sensor_Type_Id = table.Column<int>(type: "int", nullable: false),
                    Sensor_TypesSensor_Type_Id = table.Column<int>(type: "int", nullable: true),
                    Device_Id = table.Column<int>(type: "int", nullable: false),
                    DevicesDevice_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensors", x => x.Sensor_Id);
                    table.ForeignKey(
                        name: "FK_Sensors_Devices_DevicesDevice_Id",
                        column: x => x.DevicesDevice_Id,
                        principalTable: "Devices",
                        principalColumn: "Device_Id");
                    table.ForeignKey(
                        name: "FK_Sensors_Sensor_Types_Sensor_TypesSensor_Type_Id",
                        column: x => x.Sensor_TypesSensor_Type_Id,
                        principalTable: "Sensor_Types",
                        principalColumn: "Sensor_Type_Id");
                });

            migrationBuilder.CreateTable(
                name: "Water_Managements",
                columns: table => new
                {
                    Water_Management_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacity = table.Column<float>(type: "real", nullable: false),
                    Collection_Hour = table.Column<float>(type: "real", nullable: true),
                    Device_Id = table.Column<int>(type: "int", nullable: false),
                    DevicesDevice_Id = table.Column<int>(type: "int", nullable: true),
                    Water_Management_Type_Id = table.Column<int>(type: "int", nullable: false),
                    Water_Management_TypesWater_Management_Type_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Water_Managements", x => x.Water_Management_Id);
                    table.ForeignKey(
                        name: "FK_Water_Managements_Devices_DevicesDevice_Id",
                        column: x => x.DevicesDevice_Id,
                        principalTable: "Devices",
                        principalColumn: "Device_Id");
                    table.ForeignKey(
                        name: "FK_Water_Managements_Water_Management_Types_Water_Management_TypesWater_Management_Type_Id",
                        column: x => x.Water_Management_TypesWater_Management_Type_Id,
                        principalTable: "Water_Management_Types",
                        principalColumn: "Water_Management_Type_Id");
                });

            migrationBuilder.CreateTable(
                name: "Sensor_Data",
                columns: table => new
                {
                    Sensors_Data_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date_Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data = table.Column<float>(type: "real", nullable: false),
                    Sensor_Id = table.Column<int>(type: "int", nullable: false),
                    Sensor_TypeSensor_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensor_Data", x => x.Sensors_Data_Id);
                    table.ForeignKey(
                        name: "FK_Sensor_Data_Sensors_Sensor_TypeSensor_Id",
                        column: x => x.Sensor_TypeSensor_Id,
                        principalTable: "Sensors",
                        principalColumn: "Sensor_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Devices_Planting_AreasArea_Id",
                table: "Devices",
                column: "Planting_AreasArea_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_SystemsSystem_Id",
                table: "Devices",
                column: "SystemsSystem_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Irrigation_Actuators_DevicesDevice_Id",
                table: "Irrigation_Actuators",
                column: "DevicesDevice_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Irrigation_Actuators_Irrigation_Actuators_TypesIrrigation_Actuators_Type_Id",
                table: "Irrigation_Actuators",
                column: "Irrigation_Actuators_TypesIrrigation_Actuators_Type_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Irrigation_Programs_Planting_AreasArea_Id",
                table: "Irrigation_Programs",
                column: "Planting_AreasArea_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Planting_Areas_Crop_Status_Id",
                table: "Planting_Areas",
                column: "Crop_Status_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Planting_Areas_PlantsPlant_Id",
                table: "Planting_Areas",
                column: "PlantsPlant_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Sensor_Data_Sensor_TypeSensor_Id",
                table: "Sensor_Data",
                column: "Sensor_TypeSensor_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Sensors_DevicesDevice_Id",
                table: "Sensors",
                column: "DevicesDevice_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Sensors_Sensor_TypesSensor_Type_Id",
                table: "Sensors",
                column: "Sensor_TypesSensor_Type_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SystemsSystem_Id",
                table: "Users",
                column: "SystemsSystem_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_User_TypesUser_Type_Id",
                table: "Users",
                column: "User_TypesUser_Type_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Water_Managements_DevicesDevice_Id",
                table: "Water_Managements",
                column: "DevicesDevice_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Water_Managements_Water_Management_TypesWater_Management_Type_Id",
                table: "Water_Managements",
                column: "Water_Management_TypesWater_Management_Type_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Irrigation_Actuators");

            migrationBuilder.DropTable(
                name: "Irrigation_Programs");

            migrationBuilder.DropTable(
                name: "Sensor_Data");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Water_Managements");

            migrationBuilder.DropTable(
                name: "Irrigation_Actuators_Types");

            migrationBuilder.DropTable(
                name: "Sensors");

            migrationBuilder.DropTable(
                name: "User_Types");

            migrationBuilder.DropTable(
                name: "Water_Management_Types");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "Sensor_Types");

            migrationBuilder.DropTable(
                name: "Planting_Areas");

            migrationBuilder.DropTable(
                name: "Systems");

            migrationBuilder.DropTable(
                name: "Crop_Status");

            migrationBuilder.DropTable(
                name: "Plants");
        }
    }
}
