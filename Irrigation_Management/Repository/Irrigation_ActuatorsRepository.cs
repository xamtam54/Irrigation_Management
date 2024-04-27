using Irrigation_Management.Context;
using Irrigation_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Irrigation_Management.Repository
{
    public interface IIrrigationActuatorsRepository
    {
        Task<List<Irrigation_Actuators>> GetAll();
        Task<Irrigation_Actuators?> GetIrrigationActuator(int Irrigation_Actuator_Id);
        Task<Irrigation_Actuators> CreateIrrigationActuator(int Device_Id, int Irrigation_Actuators_Type_Id);
        Task<Irrigation_Actuators?> UpdateIrrigationActuator(int Irrigation_Actuator_Id, int Device_Id, int Irrigation_Actuators_Type_Id);
        Task<Irrigation_Actuators?> DeleteIrrigationActuator(Irrigation_Actuators actuatorToDelete);
    }

    public class IrrigationActuatorsRepository : IIrrigationActuatorsRepository
    {
        private readonly ManagementDBContext _db;
        public IrrigationActuatorsRepository(ManagementDBContext db)
        {
            _db = db;
        }

        public async Task<List<Irrigation_Actuators>> GetAll()
        {
            return await _db.Irrigation_Actuators.ToListAsync();
        }

        public async Task<Irrigation_Actuators?> GetIrrigationActuator(int Irrigation_Actuator_Id)
        {
            return await _db.Irrigation_Actuators.FindAsync(Irrigation_Actuator_Id);
        }

        public async Task<Irrigation_Actuators> CreateIrrigationActuator(int Device_Id, int Irrigation_Actuators_Type_Id)
        {
            Irrigation_Actuators newActuator = new Irrigation_Actuators
            {
                Device_Id = Device_Id,
                Irrigation_Actuators_Type_Id = Irrigation_Actuators_Type_Id
            };

            await _db.Irrigation_Actuators.AddAsync(newActuator);
            await _db.SaveChangesAsync();
            return newActuator;
        }

        public async Task<Irrigation_Actuators?> UpdateIrrigationActuator(int Irrigation_Actuator_Id, int Device_Id, int Irrigation_Actuators_Type_Id)
        {
            Irrigation_Actuators? actuatorToUpdate = await GetIrrigationActuator(Irrigation_Actuator_Id);

            if (actuatorToUpdate != null)
            {
                actuatorToUpdate.Device_Id = Device_Id;
                actuatorToUpdate.Irrigation_Actuators_Type_Id = Irrigation_Actuators_Type_Id;

                await _db.SaveChangesAsync();
            }

            return actuatorToUpdate;
        }

        public async Task<Irrigation_Actuators?> DeleteIrrigationActuator(Irrigation_Actuators actuatorToDelete)
        {
            if (actuatorToDelete != null)
            {
                actuatorToDelete.IsDeleted = true;
                await _db.SaveChangesAsync();
            }

            return actuatorToDelete;
        }

    }
}
