using Irrigation_Management.Models;
using Irrigation_Management.Repository;

namespace Irrigation_Management.Services
{
    public interface IWaterManagementService
    {
        Task<List<Water_Management>> GetAll();
        Task<Water_Management?> GetWaterManagement(int Water_Management_Id);
        Task<Water_Management> CreateWaterManagement(float Capacity, float Collection_Hour, int Device_Id, int Water_Management_Type_Id);
        Task<Water_Management?> UpdateWaterManagement(int Water_Management_Id, float Capacity, float? Collection_Hour, int Device_Id, int Water_Management_Type_Id);
        Task<Water_Management?> DeleteWaterManagement(int Water_Management_Id);
    }

    public class WaterManagementService : IWaterManagementService
    {
        private readonly IWaterManagementRepository _waterManagementRepository;

        public WaterManagementService(WaterManagementRepository waterManagementRepository)
        {
            _waterManagementRepository = waterManagementRepository;
        }

        public async Task<List<Water_Management>> GetAll()
        {
            return await _waterManagementRepository.GetAll();
        }

        public async Task<Water_Management?> GetWaterManagement(int Water_Management_Id)
        {
            return await _waterManagementRepository.GetWaterManagement(Water_Management_Id);
        }

        public async Task<Water_Management> CreateWaterManagement(float Capacity, float Collection_Hour, int Device_Id, int Water_Management_Type_Id)
        {
            return await _waterManagementRepository.CreateWaterManagement(Capacity, Collection_Hour, Device_Id, Water_Management_Type_Id);
        }

        public async Task<Water_Management?> UpdateWaterManagement(int Water_Management_Id, float Capacity = -1, float? Collection_Hour = null, int Device_Id = -1, int Water_Management_Type_Id = -1)
        {
            Water_Management? waterManagementToUpdate = await _waterManagementRepository.GetWaterManagement(Water_Management_Id);

            if (waterManagementToUpdate != null)
            {
                if (Capacity != -1){waterManagementToUpdate.Capacity = Capacity;}
                if (Collection_Hour != null){waterManagementToUpdate.Collection_Hour = Collection_Hour;}
                if (Device_Id != -1){waterManagementToUpdate.Device_Id = Device_Id;}
                if (Water_Management_Type_Id != -1){waterManagementToUpdate.Water_Management_Type_Id = Water_Management_Type_Id;}

                await _waterManagementRepository.UpdateWaterManagement(Water_Management_Id, waterManagementToUpdate.Capacity, (float)waterManagementToUpdate.Collection_Hour, waterManagementToUpdate.Device_Id, waterManagementToUpdate.Water_Management_Type_Id);
            }

            return waterManagementToUpdate; 
        }


        public async Task<Water_Management?> DeleteWaterManagement(int Water_Management_Id)
        {
            return await _waterManagementRepository.DeleteWaterManagement(Water_Management_Id);
        }
    }
}
