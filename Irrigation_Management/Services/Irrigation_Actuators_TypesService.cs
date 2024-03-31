using Irrigation_Management.Models;
using Irrigation_Management.Repository;

namespace Irrigation_Management.Services
{
    public interface IIrrigationActuatorsTypesService
    {
        Task<List<Irrigation_Actuators_Types>> GetAll();
        Task<Irrigation_Actuators_Types?> GetIrrigationActuatorType(int Irrigation_Actuators_Type_Id);
        Task<Irrigation_Actuators_Types> CreateIrrigationActuatorType(string Type_Name, string Description);
        Task<Irrigation_Actuators_Types?> UpdateIrrigationActuatorType(int Irrigation_Actuators_Type_Id, string Type_Name, string Description);
        Task<Irrigation_Actuators_Types?> DeleteIrrigationActuatorType(int Irrigation_Actuators_Type_Id);
    }

    public class IrrigationActuatorsTypesService : IIrrigationActuatorsTypesService
    {
        private readonly IIrrigationActuatorsTypesRepository _irrigationActuatorsTypesRepository;
        public IrrigationActuatorsTypesService(IrrigationActuatorsTypesRepository irrigationActuatorsTypesRepository)
        {
            _irrigationActuatorsTypesRepository = irrigationActuatorsTypesRepository;
        }

        public async Task<Irrigation_Actuators_Types> CreateIrrigationActuatorType(string Type_Name, string Description)
        {
            return await _irrigationActuatorsTypesRepository.CreateIrrigationActuatorType(Type_Name, Description);
        }

        public async Task<Irrigation_Actuators_Types?> DeleteIrrigationActuatorType(int Irrigation_Actuators_Type_Id)
        {
            return await _irrigationActuatorsTypesRepository.DeleteIrrigationActuatorType(Irrigation_Actuators_Type_Id);
        }

        public async Task<List<Irrigation_Actuators_Types>> GetAll()
        {
            return await _irrigationActuatorsTypesRepository.GetAll();
        }

        public async Task<Irrigation_Actuators_Types?> GetIrrigationActuatorType(int Irrigation_Actuators_Type_Id)
        {
            return await _irrigationActuatorsTypesRepository.GetIrrigationActuatorType(Irrigation_Actuators_Type_Id);
        }

        public async Task<Irrigation_Actuators_Types?> UpdateIrrigationActuatorType(int Irrigation_Actuators_Type_Id, string Type_Name = null, string Description = null)
        {
            Irrigation_Actuators_Types? typeToUpdate = await _irrigationActuatorsTypesRepository.GetIrrigationActuatorType(Irrigation_Actuators_Type_Id);

            if (typeToUpdate != null)
            {
                if (Type_Name == null) { Type_Name = typeToUpdate.Type_Name; }
                if (Description == null) { Description = typeToUpdate.Description; }

                return await _irrigationActuatorsTypesRepository.UpdateIrrigationActuatorType(Irrigation_Actuators_Type_Id, Type_Name, Description);
            }

            return null;
        }
    }
}
