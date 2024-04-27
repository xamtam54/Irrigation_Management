using Irrigation_Management.Context;
using Irrigation_Management.Models;
using Irrigation_Management.Repository;
using Irrigation_Management.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var conString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<ManagementDBContext>(options => options.UseSqlServer(conString));

builder.Services.AddScoped<IAchievementsRepository, AchievementsRepository>();
builder.Services.AddScoped<IAchievementsService, AchievementsService>();

builder.Services.AddScoped<ICropStatusRepository, CropStatusRepository>();
builder.Services.AddScoped<ICropStatusService, CropStatusService>();

builder.Services.AddScoped<IDevicesRepository, DevicesRepository>();
builder.Services.AddScoped<IDevicesService, DevicesService>();

builder.Services.AddScoped<IGamesRepository, GamesRepository>();
builder.Services.AddScoped<IGamesService, GamesService>();

builder.Services.AddScoped<IIrrigationActuatorsTypesRepository, IrrigationActuatorsTypesRepository>();
builder.Services.AddScoped<IIrrigationActuatorsTypesService, IrrigationActuatorsTypesService>();

builder.Services.AddScoped<IIrrigationActuatorsRepository, IrrigationActuatorsRepository>();
builder.Services.AddScoped<IIrrigationActuatorsService, IrrigationActuatorsService>();

builder.Services.AddScoped<IIrrigationProgramsRepository, IrrigationProgramsRepository>();
builder.Services.AddScoped<IIrrigationProgramsService, IrrigationProgramsService>();

builder.Services.AddScoped<IPlanting_AreasRepository, Planting_AreasRepository>();
builder.Services.AddScoped<IPlanting_AreasService, Planting_AreasService>();

builder.Services.AddScoped<IPlantsRepository, PlantsRepository>();
builder.Services.AddScoped<IPlantsService, PlantsService>();

builder.Services.AddScoped<IScoreRepository, ScoreRepository>();
builder.Services.AddScoped<IScoreService, ScoreService>();

builder.Services.AddScoped<ISensorDataRepository, SensorDataRepository>();
builder.Services.AddScoped<ISensorDataService, SensorDataService>();

builder.Services.AddScoped<ISensorTypesRepository, SensorTypesRepository>();
builder.Services.AddScoped<ISensorTypesService, SensorTypesService>();

builder.Services.AddScoped<ISensorsRepository, SensorsRepository>();
builder.Services.AddScoped<ISensorsService, SensorsService>();

builder.Services.AddScoped<ISystemsRepository, SystemsRepository>();
builder.Services.AddScoped<ISystemsService, SystemsService>();

builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IUsersService, UsersService>();

builder.Services.AddScoped<IUser_TypesRepository, User_TypesRepository>();
builder.Services.AddScoped<IUser_TypesService, User_TypesService>();

builder.Services.AddScoped<IWaterManagementTypesRepository, WaterManagementTypesRepository>();
builder.Services.AddScoped<IWaterManagementTypesService, WaterManagementTypesService>();

builder.Services.AddScoped<IWaterManagementRepository, WaterManagementRepository>();
builder.Services.AddScoped<IWaterManagementService, WaterManagementService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
