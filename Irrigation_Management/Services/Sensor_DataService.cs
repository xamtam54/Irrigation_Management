using Irrigation_Management.Models;
using Irrigation_Management.Repository;

namespace Irrigation_Management.Services
{
    public interface ISensorDataService
    {
        Task<List<Sensor_Data>> GetAll();
        Task<Sensor_Data?> GetSensorData(int Sensor_Data_Id);
        Task<Sensor_Data> CreateSensorData(DateTime Date_Time, float Data, int Sensor_Id);
        Task<Sensor_Data?> UpdateSensorData(int Sensor_Data_Id, DateTime Date_Time, float Data, int Sensor_Id);
        Task<Sensor_Data?> DeleteSensorData(int Sensor_Data_Id);
    }

    public class SensorDataService : ISensorDataService
    {
        private readonly ISensorDataRepository _sensorDataRepository;
        public SensorDataService(ISensorDataRepository sensorDataRepository)
        {
            _sensorDataRepository = sensorDataRepository;
        }

        public async Task<Sensor_Data> CreateSensorData(DateTime Date_Time, float Data, int Sensor_Id)
        {
            return await _sensorDataRepository.CreateSensorData(Date_Time, Data, Sensor_Id);
        }

        public async Task<Sensor_Data?> DeleteSensorData(int Sensor_Data_Id)
        {
            return await _sensorDataRepository.DeleteSensorData(Sensor_Data_Id);
        }

        public async Task<List<Sensor_Data>> GetAll()
        {
            return await _sensorDataRepository.GetAll();
        }

        public async Task<Sensor_Data?> GetSensorData(int Sensor_Data_Id)
        {
            return await _sensorDataRepository.GetSensorData(Sensor_Data_Id);
        }

        public async Task<Sensor_Data?> UpdateSensorData(int Sensor_Data_Id, DateTime Date_Time = default, float Data = default, int Sensor_Id = default)
        {
            Sensor_Data? dataToUpdate = await _sensorDataRepository.GetSensorData(Sensor_Data_Id);

            if (dataToUpdate != null)
            {
                if (Date_Time != default) dataToUpdate.Date_Time = Date_Time;
                if (Data != default) dataToUpdate.Data = Data;
                if (Sensor_Id != default) dataToUpdate.Sensor_Id = Sensor_Id;

                await _sensorDataRepository.UpdateSensorData(Sensor_Data_Id, dataToUpdate.Date_Time, dataToUpdate.Data, dataToUpdate.Sensor_Id);
            }

            return dataToUpdate;
        }
    }
}
