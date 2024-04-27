using Irrigation_Management.Models;
using Irrigation_Management.Repository;

namespace Irrigation_Management.Services
{
    public interface ICropStatusService
    {
        Task<List<Crop_Status>> GetAll();
        Task<Crop_Status?> GetCropStatus(int Crop_Status_Id);
        Task<Crop_Status> CreateCropStatus(string Crop_Status_Name, decimal Production_Percentage);
        Task<Crop_Status?> UpdateCropStatus(int Crop_Status_Id, string? Crop_Status_Name, decimal? Production_Percentage);
        Task<Crop_Status?> DeleteCropStatus(int Crop_Status_Id);
    }

    public class CropStatusService : ICropStatusService
    {
        private readonly ICropStatusRepository _cropStatusRepository;

        public CropStatusService(ICropStatusRepository cropStatusRepository)
        {
            _cropStatusRepository = cropStatusRepository;
        }

        public async Task<List<Crop_Status>> GetAll()
        {
            return await _cropStatusRepository.GetAll();
        }

        public async Task<Crop_Status?> GetCropStatus(int Crop_Status_Id)
        {
            return await _cropStatusRepository.GetCropStatus(Crop_Status_Id);
        }

        public async Task<Crop_Status> CreateCropStatus(string Crop_Status_Name, decimal Production_Percentage)
        {
            return await _cropStatusRepository.CreateCropStatus(Crop_Status_Name, Production_Percentage);
        }

        public async Task<Crop_Status?> UpdateCropStatus(int Crop_Status_Id, string? Crop_Status_Name = null, decimal? Production_Percentage = -1)
        {
            Crop_Status? cropStatusToUpdate = await _cropStatusRepository.GetCropStatus(Crop_Status_Id);

            if (cropStatusToUpdate != null)
            {
                if (Crop_Status_Name == null) { Crop_Status_Name = cropStatusToUpdate.Crop_Status_Name; }
                if (Production_Percentage == -1) { Production_Percentage = cropStatusToUpdate.Production_Percentage; }

                return await _cropStatusRepository.UpdateCropStatus(Crop_Status_Id, Crop_Status_Name, (decimal)Production_Percentage);
            }

            return cropStatusToUpdate;
        }


        public async Task<Crop_Status?> DeleteCropStatus(int Crop_Status_Id)
        {
            Crop_Status? cropStatus = await _cropStatusRepository.GetCropStatus(Crop_Status_Id);

            if (cropStatus != null)
            {
                cropStatus.IsDeleted = true;
                // cropStatus.Date = DateTime.Now;
                return await _cropStatusRepository.DeleteCropStatus(cropStatus);
            }

            return null;
        }

    }
}
