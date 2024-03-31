using Irrigation_Management.Models;
using Irrigation_Management.Repository;

namespace Irrigation_Management.Services
{
    public interface IWaterManagementTypesService
    {
        Task<List<Water_Management_Types>> GetAll();
        Task<Water_Management_Types?> GetWaterManagementType(int Water_Management_Type_Id);
        Task<Water_Management_Types> CreateWaterManagementType(string Type_Name, string Description, string Material);
        Task<Water_Management_Types?> UpdateWaterManagementType(int Water_Management_Type_Id, string Type_Name, string Description, string Material);
        Task<Water_Management_Types?> DeleteWaterManagementType(int Water_Management_Type_Id);
    }

    public class WaterManagementTypesService : IWaterManagementTypesService
    {
        private readonly IWaterManagementTypesRepository _waterManagementTypesRepository;
        public WaterManagementTypesService(WaterManagementTypesRepository waterManagementTypesRepository)
        {
            _waterManagementTypesRepository = waterManagementTypesRepository;
        }

        public async Task<Water_Management_Types> CreateWaterManagementType(string Type_Name, string Description, string Material)
        {
            return await _waterManagementTypesRepository.CreateWaterManagementType(Type_Name, Description, Material);
        }

        public async Task<Water_Management_Types?> DeleteWaterManagementType(int Water_Management_Type_Id)
        {
            return await _waterManagementTypesRepository.DeleteWaterManagementType(Water_Management_Type_Id);
        }

        public async Task<List<Water_Management_Types>> GetAll()
        {
            return await _waterManagementTypesRepository.GetAll();
        }

        public async Task<Water_Management_Types?> GetWaterManagementType(int Water_Management_Type_Id)
        {
            return await _waterManagementTypesRepository.GetWaterManagementType(Water_Management_Type_Id);
        }

        public async Task<Water_Management_Types?> UpdateWaterManagementType(int Water_Management_Type_Id, string Type_Name = null, string Description = null, string Material = null)
        {
            Water_Management_Types? typeToUpdate = await _waterManagementTypesRepository.GetWaterManagementType(Water_Management_Type_Id);

            if (typeToUpdate != null)
            {
                if (Type_Name == null) { Type_Name = typeToUpdate.Type_Name; }
                if (Description == null) { Description = typeToUpdate.Description; }
                if (Material == null) { Material = typeToUpdate.Material; }

                await _waterManagementTypesRepository.UpdateWaterManagementType(Water_Management_Type_Id, Type_Name, Description, Material);
            }

            return typeToUpdate;
        }
    }
}
