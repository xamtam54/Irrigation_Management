using Irrigation_Management.Context;
using Irrigation_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Irrigation_Management.Repository
{
    public interface IWaterManagementRepository
    {
        Task<List<Water_Management>> GetAll();
        Task<Water_Management?> GetWaterManagement(int Water_Management_Id);
        Task<Water_Management> CreateWaterManagement(float Capacity, float Collection_Hour, int Device_Id, int Water_Management_Type_Id);
        Task<Water_Management?> UpdateWaterManagement(int Water_Management_Id, float Capacity, float Collection_Hour, int Device_Id, int Water_Management_Type_Id);
        Task<Water_Management?> DeleteWaterManagement(Water_Management waterManagementToDelete);
    }

    public class WaterManagementRepository : IWaterManagementRepository
    {
        private readonly ManagementDBContext _db;

        public WaterManagementRepository(ManagementDBContext db)
        {
            _db = db;
        }

        public async Task<List<Water_Management>> GetAll()
        {
            return await _db.Water_Managements.ToListAsync();
        }

        public async Task<Water_Management?> GetWaterManagement(int Water_Management_Id)
        {
            return await _db.Water_Managements.FindAsync(Water_Management_Id);
        }

        public async Task<Water_Management> CreateWaterManagement(float Capacity, float Collection_Hour, int Device_Id, int Water_Management_Type_Id)
        {
            Water_Management newWaterManagement = new Water_Management
            {
                Capacity = Capacity,
                Collection_Hour = Collection_Hour,
                Device_Id = Device_Id,
                Water_Management_Type_Id = Water_Management_Type_Id
            };

            await _db.Water_Managements.AddAsync(newWaterManagement);
            await _db.SaveChangesAsync();
            return newWaterManagement;
        }

        public async Task<Water_Management?> UpdateWaterManagement(int Water_Management_Id, float Capacity, float Collection_Hour, int Device_Id, int Water_Management_Type_Id)
        {
            Water_Management? waterManagementToUpdate = await GetWaterManagement(Water_Management_Id);

            if (waterManagementToUpdate != null)
            {
                waterManagementToUpdate.Capacity = Capacity;
                waterManagementToUpdate.Collection_Hour = Collection_Hour;
                waterManagementToUpdate.Device_Id = Device_Id;
                waterManagementToUpdate.Water_Management_Type_Id = Water_Management_Type_Id;

                await _db.SaveChangesAsync();
            }

            return waterManagementToUpdate;
        }

        public async Task<Water_Management?> DeleteWaterManagement(Water_Management waterManagementToDelete)
        {
            if (waterManagementToDelete != null)
            {
                waterManagementToDelete.IsDeleted = true;
                await _db.SaveChangesAsync();
            }

            return waterManagementToDelete;
        }
    }
}
