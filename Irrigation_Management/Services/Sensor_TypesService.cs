using Irrigation_Management.Models;
using Irrigation_Management.Repository;

namespace Irrigation_Management.Services
{
    public interface ISensorTypesService
    {
        Task<List<Sensor_Types>> GetAll();
        Task<Sensor_Types?> GetSensorType(int Sensor_Type_Id);
        Task<Sensor_Types> CreateSensorType(string Sensor_Type, string Description, string Measure_Unit);
        Task<Sensor_Types?> UpdateSensorType(int Sensor_Type_Id, string Sensor_Type, string Description, string Measure_Unit);
        Task<Sensor_Types?> DeleteSensorType(int Sensor_Type_Id);
    }

    public class SensorTypesService : ISensorTypesService
    {
        private readonly ISensorTypesRepository _sensorTypesRepository;
        public SensorTypesService(ISensorTypesRepository sensorTypesRepository)
        {
            _sensorTypesRepository = sensorTypesRepository;
        }

        public async Task<Sensor_Types> CreateSensorType(string Sensor_Type, string Description, string Measure_Unit)
        {
            return await _sensorTypesRepository.CreateSensorType(Sensor_Type, Description, Measure_Unit);
        }

        public async Task<Sensor_Types?> DeleteSensorType(int Sensor_Type_Id)
        {
            return await _sensorTypesRepository.DeleteSensorType(Sensor_Type_Id);
        }

        public async Task<List<Sensor_Types>> GetAll()
        {
            return await _sensorTypesRepository.GetAll();
        }

        public async Task<Sensor_Types?> GetSensorType(int Sensor_Type_Id)
        {
            return await _sensorTypesRepository.GetSensorType(Sensor_Type_Id);
        }

        public async Task<Sensor_Types?> UpdateSensorType(int Sensor_Type_Id, string Sensor_Type = null, string Description = null, string Measure_Unit = null)
        {
            Sensor_Types? typeToUpdate = await _sensorTypesRepository.GetSensorType(Sensor_Type_Id);

            if (typeToUpdate != null)
            {
                if (Sensor_Type != null) typeToUpdate.Sensor_Type = Sensor_Type;
                if (Description != null) typeToUpdate.Description = Description;
                if (Measure_Unit != null) typeToUpdate.Measure_Unit = Measure_Unit;

                await _sensorTypesRepository.UpdateSensorType(Sensor_Type_Id, typeToUpdate.Sensor_Type, typeToUpdate.Description, typeToUpdate.Measure_Unit);
            }

            return typeToUpdate;
        }
    }
}
