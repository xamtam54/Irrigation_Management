using Irrigation_Management.Context;
using Irrigation_Management.Models;
using Microsoft.EntityFrameworkCore;
using static Azure.Core.HttpHeader;

namespace Irrigation_Management.Repository
{
    public interface IPlanting_AreasRepository
    {
        Task<List<Planting_Areas>> GetPlanting_Areas();
        Task<Planting_Areas?> GetPlanting_Area(int Area_Id);
        Task<Planting_Areas> CreatePlanting_Areas(int Crop_Status_Id, int Plant_Id);
        Task<Planting_Areas?> UpdatePlanting_Areas(int Area_Id, int Crop_Status_Id, int Plant_Id);
        Task<Planting_Areas?> DeletePlanting_Areas(Planting_Areas areaToDelete);
    }
    public class Planting_AreasRepository : IPlanting_AreasRepository
    {
        private readonly ManagementDBContext _db;
        public Planting_AreasRepository(ManagementDBContext db)
        {
            _db = db;
        }

        public async Task<Planting_Areas> CreatePlanting_Areas(int Crop_Status_Id, int Plant_Id)
        {
            Planting_Areas newArea = new Planting_Areas
            {
                Crop_Status_Id = Crop_Status_Id,
                Plant_Id = Plant_Id
            };

            await _db.Planting_Areas.AddAsync(newArea);
            _db.SaveChanges();
            return newArea;
        }

        public async Task<Planting_Areas?> DeletePlanting_Areas(Planting_Areas areaToDelete)
        {
            if (areaToDelete != null)
            {
                areaToDelete.IsDeleted = true;
                await _db.SaveChangesAsync();
            }

            return areaToDelete;
        }

        public async Task<Planting_Areas?> GetPlanting_Area(int Area_Id)
        {
            return await _db.Planting_Areas.FindAsync(Area_Id);
        }

        public async Task<List<Planting_Areas>> GetPlanting_Areas()
        {
            return await _db.Planting_Areas.ToListAsync();
        }

        public async Task<Planting_Areas?> UpdatePlanting_Areas(int Area_Id, int Crop_Status_Id, int Plant_Id)
        {
            Planting_Areas? planting_AreaToUpdate = await GetPlanting_Area(Area_Id);

            if (planting_AreaToUpdate != null)
            {
                planting_AreaToUpdate.Crop_Status_Id = Crop_Status_Id;
                planting_AreaToUpdate.Plant_Id = Plant_Id;

                await _db.SaveChangesAsync();
            }

            return planting_AreaToUpdate;
        }
    }
}
