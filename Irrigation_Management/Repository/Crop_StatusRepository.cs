using Irrigation_Management.Context;
using Irrigation_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Irrigation_Management.Repository
{
    public interface ICropStatusRepository
    {
        Task<List<Crop_Status>> GetAll();
        Task<Crop_Status?> GetCropStatus(int Crop_Status_Id);
        Task<Crop_Status> CreateCropStatus(string Crop_Status_Name, decimal Production_Percentage);
        Task<Crop_Status?> UpdateCropStatus(int Crop_Status_Id, string Crop_Status_Name, decimal Production_Percentage);
        Task<Crop_Status?> DeleteCropStatus(Crop_Status cropStatusToDelete);
    }

    public class CropStatusRepository : ICropStatusRepository
    {
        private readonly ManagementDBContext _db;

        public CropStatusRepository(ManagementDBContext db)
        {
            _db = db;
        }

        public async Task<List<Crop_Status>> GetAll()
        {
            return await _db.Crop_Status.ToListAsync();
        }

        public async Task<Crop_Status?> GetCropStatus(int Crop_Status_Id)
        {
            return await _db.Crop_Status.FindAsync(Crop_Status_Id);
        }

        public async Task<Crop_Status> CreateCropStatus(string Crop_Status_Name, decimal Production_Percentage)
        {
            Crop_Status newCropStatus = new Crop_Status
            {
                Crop_Status_Name = Crop_Status_Name,
                Production_Percentage = Production_Percentage
            };

            await _db.Crop_Status.AddAsync(newCropStatus);
            await _db.SaveChangesAsync();
            return newCropStatus;
        }

        public async Task<Crop_Status?> UpdateCropStatus(int Crop_Status_Id, string Crop_Status_Name, decimal Production_Percentage)
        {
            Crop_Status? cropStatusToUpdate = await GetCropStatus(Crop_Status_Id);

            if (cropStatusToUpdate != null)
            {
                cropStatusToUpdate.Crop_Status_Name = Crop_Status_Name;
                cropStatusToUpdate.Production_Percentage = Production_Percentage;

                await _db.SaveChangesAsync();
            }

            return cropStatusToUpdate;
        }

        public async Task<Crop_Status?> DeleteCropStatus(Crop_Status cropStatusToDelete)
        {
            if (cropStatusToDelete != null)
            {
                cropStatusToDelete.IsDeleted = true;
                await _db.SaveChangesAsync();
            }

            return cropStatusToDelete;
        }

    }
}
