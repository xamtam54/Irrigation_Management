using Irrigation_Management.Context;
using Irrigation_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Irrigation_Management.Repository
{
    public interface ISensorTypesRepository
    {
        Task<List<Sensor_Types>> GetAll();
        Task<Sensor_Types?> GetSensorType(int Sensor_Type_Id);
        Task<Sensor_Types> CreateSensorType(string Sensor_Type, string Description, string Measure_Unit);
        Task<Sensor_Types?> UpdateSensorType(int Sensor_Type_Id, string Sensor_Type, string Description, string Measure_Unit);
        Task<Sensor_Types?> DeleteSensorType(int Sensor_Type_Id);
    }

    public class SensorTypesRepository : ISensorTypesRepository
    {
        private readonly ManagementDBContext _db;
        public SensorTypesRepository(ManagementDBContext db)
        {
            _db = db;
        }

        public async Task<List<Sensor_Types>> GetAll()
        {
            return await _db.Sensor_Types.ToListAsync();
        }

        public async Task<Sensor_Types?> GetSensorType(int Sensor_Type_Id)
        {
            return await _db.Sensor_Types.FindAsync(Sensor_Type_Id);
        }

        public async Task<Sensor_Types> CreateSensorType(string Sensor_Type, string Description, string Measure_Unit)
        {
            Sensor_Types newType = new Sensor_Types
            {
                Sensor_Type = Sensor_Type,
                Description = Description,
                Measure_Unit = Measure_Unit
            };

            await _db.Sensor_Types.AddAsync(newType);
            await _db.SaveChangesAsync();
            return newType;
        }

        public async Task<Sensor_Types?> UpdateSensorType(int Sensor_Type_Id, string Sensor_Type, string Description, string Measure_Unit)
        {
            Sensor_Types? typeToUpdate = await GetSensorType(Sensor_Type_Id);

            if (typeToUpdate != null)
            {
                typeToUpdate.Sensor_Type = Sensor_Type;
                typeToUpdate.Description = Description;
                typeToUpdate.Measure_Unit = Measure_Unit;

                await _db.SaveChangesAsync();
            }

            return typeToUpdate;
        }

        public async Task<Sensor_Types?> DeleteSensorType(int Sensor_Type_Id)
        {
            Sensor_Types? typeToDelete = await GetSensorType(Sensor_Type_Id);

            if (typeToDelete != null)
            {
                _db.Sensor_Types.Remove(typeToDelete);
                await _db.SaveChangesAsync();
            }

            return typeToDelete;
        }
    }
}
