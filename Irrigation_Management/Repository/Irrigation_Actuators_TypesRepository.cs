using Irrigation_Management.Context;
using Irrigation_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Irrigation_Management.Repository
{
    public interface IIrrigationActuatorsTypesRepository
    {
        Task<List<Irrigation_Actuators_Types>> GetAll();
        Task<Irrigation_Actuators_Types?> GetIrrigationActuatorType(int Irrigation_Actuators_Type_Id);
        Task<Irrigation_Actuators_Types> CreateIrrigationActuatorType(string Type_Name, string Description);
        Task<Irrigation_Actuators_Types?> UpdateIrrigationActuatorType(int Irrigation_Actuators_Type_Id, string Type_Name, string Description);
        Task<Irrigation_Actuators_Types?> DeleteIrrigationActuatorType(int Irrigation_Actuators_Type_Id);
    }

    public class IrrigationActuatorsTypesRepository : IIrrigationActuatorsTypesRepository
    {
        private readonly ManagementDBContext _db;
        public IrrigationActuatorsTypesRepository(ManagementDBContext db)
        {
            _db = db;
        }

        public async Task<List<Irrigation_Actuators_Types>> GetAll()
        {
            return await _db.Irrigation_Actuators_Types.ToListAsync();
        }

        public async Task<Irrigation_Actuators_Types?> GetIrrigationActuatorType(int Irrigation_Actuators_Type_Id)
        {
            return await _db.Irrigation_Actuators_Types.FindAsync(Irrigation_Actuators_Type_Id);
        }

        public async Task<Irrigation_Actuators_Types> CreateIrrigationActuatorType(string Type_Name, string Description)
        {
            Irrigation_Actuators_Types newType = new Irrigation_Actuators_Types
            {
                Type_Name = Type_Name,
                Description = Description
            };

            await _db.Irrigation_Actuators_Types.AddAsync(newType);
            await _db.SaveChangesAsync();
            return newType;
        }

        public async Task<Irrigation_Actuators_Types?> UpdateIrrigationActuatorType(int Irrigation_Actuators_Type_Id, string Type_Name, string Description)
        {
            Irrigation_Actuators_Types? typeToUpdate = await GetIrrigationActuatorType(Irrigation_Actuators_Type_Id);

            if (typeToUpdate != null)
            {
                typeToUpdate.Type_Name = Type_Name;
                typeToUpdate.Description = Description;

                await _db.SaveChangesAsync();
            }

            return typeToUpdate;
        }

        public async Task<Irrigation_Actuators_Types?> DeleteIrrigationActuatorType(int Irrigation_Actuators_Type_Id)
        {
            Irrigation_Actuators_Types? typeToDelete = await GetIrrigationActuatorType(Irrigation_Actuators_Type_Id);

            if (typeToDelete != null)
            {
                _db.Irrigation_Actuators_Types.Remove(typeToDelete);
                await _db.SaveChangesAsync();
            }

            return typeToDelete;
        }
    }
}
