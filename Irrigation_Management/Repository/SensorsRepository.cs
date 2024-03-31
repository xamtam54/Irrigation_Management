using Irrigation_Management.Context;
using Irrigation_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Irrigation_Management.Repository
{
    public interface ISensorsRepository
    {
        Task<List<Sensors>> GetAll();
        Task<Sensors?> GetSensor(int Sensor_Id);
        Task<Sensors> CreateSensor(int Sensor_Type_Id, int Device_Id);
        Task<Sensors?> UpdateSensor(int Sensor_Id, int Sensor_Type_Id, int Device_Id);
        Task<Sensors?> DeleteSensor(int Sensor_Id);
    }

    public class SensorsRepository : ISensorsRepository
    {
        private readonly ManagementDBContext _db;
        public SensorsRepository(ManagementDBContext db)
        {
            _db = db;
        }

        public async Task<List<Sensors>> GetAll()
        {
            return await _db.Sensors.ToListAsync();
        }

        public async Task<Sensors?> GetSensor(int Sensor_Id)
        {
            return await _db.Sensors.FindAsync(Sensor_Id);
        }

        public async Task<Sensors> CreateSensor(int Sensor_Type_Id, int Device_Id)
        {
            Sensors newSensor = new Sensors
            {
                Sensor_Type_Id = Sensor_Type_Id,
                Device_Id = Device_Id
            };

            await _db.Sensors.AddAsync(newSensor);
            await _db.SaveChangesAsync();
            return newSensor;
        }

        public async Task<Sensors?> UpdateSensor(int Sensor_Id, int Sensor_Type_Id, int Device_Id)
        {
            Sensors? sensorToUpdate = await GetSensor(Sensor_Id);

            if (sensorToUpdate != null)
            {
                sensorToUpdate.Sensor_Type_Id = Sensor_Type_Id;
                sensorToUpdate.Device_Id = Device_Id;

                await _db.SaveChangesAsync();
            }

            return sensorToUpdate;
        }

        public async Task<Sensors?> DeleteSensor(int Sensor_Id)
        {
            Sensors? sensorToDelete = await GetSensor(Sensor_Id);

            if (sensorToDelete != null)
            {
                _db.Sensors.Remove(sensorToDelete);
                await _db.SaveChangesAsync();
            }

            return sensorToDelete;
        }
    }
}
