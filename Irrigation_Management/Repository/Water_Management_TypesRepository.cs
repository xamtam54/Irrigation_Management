using Irrigation_Management.Context;
using Irrigation_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Irrigation_Management.Repository
{
    public interface IWaterManagementTypesRepository
    {
        Task<List<Water_Management_Types>> GetAll();
        Task<Water_Management_Types?> GetWaterManagementType(int Water_Management_Type_Id);
        Task<Water_Management_Types> CreateWaterManagementType(string Type_Name, string Description, string Material);
        Task<Water_Management_Types?> UpdateWaterManagementType(int Water_Management_Type_Id, string Type_Name, string Description, string Material);
        Task<Water_Management_Types?> DeleteWaterManagementType(Water_Management_Types typeToDelete);
    }

    public class WaterManagementTypesRepository : IWaterManagementTypesRepository
    {
        private readonly ManagementDBContext _db;
        public WaterManagementTypesRepository(ManagementDBContext db)
        {
            _db = db;
        }

        public async Task<List<Water_Management_Types>> GetAll()
        {
            return await _db.Water_Management_Types.ToListAsync();
        }

        public async Task<Water_Management_Types?> GetWaterManagementType(int Water_Management_Type_Id)
        {
            return await _db.Water_Management_Types.FindAsync(Water_Management_Type_Id);
        }

        public async Task<Water_Management_Types> CreateWaterManagementType(string Type_Name, string Description, string Material)
        {
            Water_Management_Types newType = new Water_Management_Types
            {
                Type_Name = Type_Name,
                Description = Description,
                Material = Material
            };

            await _db.Water_Management_Types.AddAsync(newType);
            await _db.SaveChangesAsync();
            return newType;
        }

        public async Task<Water_Management_Types?> UpdateWaterManagementType(int Water_Management_Type_Id, string Type_Name, string Description, string Material)
        {
            Water_Management_Types? typeToUpdate = await GetWaterManagementType(Water_Management_Type_Id);

            if (typeToUpdate != null)
            {
                typeToUpdate.Type_Name = Type_Name;
                typeToUpdate.Description = Description;
                typeToUpdate.Material = Material;

                await _db.SaveChangesAsync();
            }

            return typeToUpdate;
        }

        public async Task<Water_Management_Types?> DeleteWaterManagementType(Water_Management_Types typeToDelete)
        {
            if (typeToDelete != null)
            {
                typeToDelete.IsDeleted = true;
                await _db.SaveChangesAsync();
            }

            return typeToDelete;
        }
    }
}
