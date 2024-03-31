using Irrigation_Management.Models;
using Irrigation_Management.Repository;

namespace Irrigation_Management.Services
{
    public interface IIrrigationActuatorsService
    {
        Task<List<Irrigation_Actuators>> GetAll();
        Task<Irrigation_Actuators?> GetIrrigationActuator(int Irrigation_Actuator_Id);
        Task<Irrigation_Actuators> CreateIrrigationActuator(int Device_Id, int Irrigation_Actuators_Type_Id);
        Task<Irrigation_Actuators?> UpdateIrrigationActuator(int Irrigation_Actuator_Id, int Device_Id, int Irrigation_Actuators_Type_Id);
        Task<Irrigation_Actuators?> DeleteIrrigationActuator(int Irrigation_Actuator_Id);
    }

    public class IrrigationActuatorsService : IIrrigationActuatorsService
    {
        private readonly IIrrigationActuatorsRepository _irrigationActuatorsRepository;
        public IrrigationActuatorsService(IrrigationActuatorsRepository irrigationActuatorsRepository)
        {
            _irrigationActuatorsRepository = irrigationActuatorsRepository;
        }

        public async Task<Irrigation_Actuators> CreateIrrigationActuator(int Device_Id, int Irrigation_Actuators_Type_Id)
        {
            return await _irrigationActuatorsRepository.CreateIrrigationActuator(Device_Id, Irrigation_Actuators_Type_Id);
        }

        public async Task<Irrigation_Actuators?> DeleteIrrigationActuator(int Irrigation_Actuator_Id)
        {
            return await _irrigationActuatorsRepository.DeleteIrrigationActuator(Irrigation_Actuator_Id);
        }

        public async Task<List<Irrigation_Actuators>> GetAll()
        {
            return await _irrigationActuatorsRepository.GetAll();
        }

        public async Task<Irrigation_Actuators?> GetIrrigationActuator(int Irrigation_Actuator_Id)
        {
            return await _irrigationActuatorsRepository.GetIrrigationActuator(Irrigation_Actuator_Id);
        }

        public async Task<Irrigation_Actuators?> UpdateIrrigationActuator(int Irrigation_Actuator_Id, int Device_Id = -1, int Irrigation_Actuators_Type_Id = -1)
        {
            Irrigation_Actuators? actuatorToUpdate = await _irrigationActuatorsRepository.GetIrrigationActuator(Irrigation_Actuator_Id);
            if (actuatorToUpdate != null)
            {
                if (Device_Id != -1) actuatorToUpdate.Device_Id = Device_Id;
                if (Irrigation_Actuators_Type_Id != -1) actuatorToUpdate.Irrigation_Actuators_Type_Id = Irrigation_Actuators_Type_Id;
                
                await _irrigationActuatorsRepository.UpdateIrrigationActuator(Irrigation_Actuator_Id, actuatorToUpdate.Device_Id, actuatorToUpdate.Irrigation_Actuators_Type_Id);
            }
            return actuatorToUpdate;
        }
    }
}
