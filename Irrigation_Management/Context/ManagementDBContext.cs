using Irrigation_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Irrigation_Management.Context
{
    public class ManagementDBContext:DbContext
    {
        public ManagementDBContext(DbContextOptions<ManagementDBContext> options) : base (options)
        {
            
        }
        
        public DbSet<Devices> Devices { get; set; } = null!;
        public DbSet<Irrigation_Actuators> Irrigation_Actuators { get; set; } = null!;
        public DbSet<Irrigation_Actuators_Types> Irrigation_Actuators_Types { get; set; } = null!;
        public DbSet<Irrigation_Programs> Irrigation_Programs { get; set; } = null!;    
        public DbSet<Planting_Areas> Planting_Areas { get; set; } = null!;
        public DbSet<Plants> Plants { get; set; } = null!;  
        public DbSet<Sensor_Data> Sensor_Data { get; set; } = null!;
        public DbSet<Sensor_Types> Sensor_Types { get; set; } = null!;
        public DbSet<Sensors> Sensors { get; set; } = null!;
        public DbSet<Systems> Systems { get; set; } = null!;
        public DbSet<User_Types> User_Types { get; set; } = null!;
        public DbSet<Users> Users { get; set; } = null!;
        public DbSet<Water_Management> Water_Managements { get; set; } = null!;
        public DbSet<Water_Management_Types> Water_Management_Types { get; set; } = null!;
        public DbSet<Crop_Status> Crop_Status { get; set; } = null!;
        public DbSet<Achievements> Achievements { get; set;} = null!;
        public DbSet<Allocation_Systems> Allocation_Systems { get; set; } = null!;
        public DbSet<Games> Games { get; set; } = null!;
        public DbSet<Score> Scores { get; set; } = null!;

    }
}
