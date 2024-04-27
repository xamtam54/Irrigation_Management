using Irrigation_Management.Models;
using Irrigation_Management.Repository;

namespace Irrigation_Management.Services
{
    public interface ISensorsService
    {
        Task<List<Sensors>> GetAll();
        Task<Sensors?> GetSensor(int Sensor_Id);
        Task<Sensors> CreateSensor(int Sensor_Type_Id, int Device_Id);
        Task<Sensors?> UpdateSensor(int Sensor_Id, int? Sensor_Type_Id, int? Device_Id);
        Task<Sensors?> DeleteSensor(int Sensor_Id);
    }

    public class SensorsService : ISensorsService
    {
        private readonly ISensorsRepository _sensorsRepository;
        public SensorsService(ISensorsRepository sensorsRepository)
        {
            _sensorsRepository = sensorsRepository;
        }

        public async Task<Sensors> CreateSensor(int Sensor_Type_Id, int Device_Id)
        {
            return await _sensorsRepository.CreateSensor(Sensor_Type_Id, Device_Id);
        }

        public async Task<Sensors?> DeleteSensor(int Sensor_Id)
        {
            Sensors? sensor = await _sensorsRepository.GetSensor(Sensor_Id);

            if (sensor != null)
            {
                sensor.IsDeleted = true;
                // sensor.Date = DateTime.Now;
                return await _sensorsRepository.DeleteSensor(sensor);
            }

            return null;
        }

        public async Task<List<Sensors>> GetAll()
        {
            return await _sensorsRepository.GetAll();
        }

        public async Task<Sensors?> GetSensor(int Sensor_Id)
        {
            return await _sensorsRepository.GetSensor(Sensor_Id);
        }

        public async Task<Sensors?> UpdateSensor(int Sensor_Id, int? Sensor_Type_Id = -1, int? Device_Id = -1)
        {
            Sensors? sensorToUpdate = await _sensorsRepository.GetSensor(Sensor_Id);

            if (sensorToUpdate != null)
            {
                if (Sensor_Type_Id != -1) sensorToUpdate.Sensor_Type_Id = (int)Sensor_Type_Id;
                if (Device_Id != -1) sensorToUpdate.Device_Id = (int)Device_Id;

                await _sensorsRepository.UpdateSensor(Sensor_Id, sensorToUpdate.Sensor_Type_Id, sensorToUpdate.Device_Id);
            }

            return sensorToUpdate;
        }
    }
}
