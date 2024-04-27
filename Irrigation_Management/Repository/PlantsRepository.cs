using Irrigation_Management.Context;
using Irrigation_Management.Models;
using Microsoft.EntityFrameworkCore;
using static Azure.Core.HttpHeader;

namespace Irrigation_Management.Repository
{
    public interface IPlantsRepository
    {
        Task<List<Plants>> GetPlants();
        Task<Plants?> GetPlant(int Plant_Id);
        Task<Plants> CreatePlants(string Plant_Name, string Specie, float Min_PH, float Max_PH, float Requirement_Liters);
        Task<Plants?> UpdatePlants(int Plant_Id, string Plant_Name, string Specie, float Min_PH, float Max_PH, float Requirement_Liters);
        Task<Plants?> DeletePlants(Plants plantToDelete);
    }
    public class PlantsRepository : IPlantsRepository
    {
        private readonly ManagementDBContext _db;
        public PlantsRepository(ManagementDBContext db)
        {
            _db = db;
        }

        public async Task<Plants> CreatePlants(string Plant_Name, string Specie, float Min_PH, float Max_PH, float Requirement_Liters)
        {
            Plants newPlant = new Plants
            {
                Plant_Name = Plant_Name,
                Specie = Specie,
                Min_PH = Min_PH,
                Max_PH = Max_PH,
                Requirement_Liters = Requirement_Liters,
            };

            await _db.Plants.AddAsync(newPlant);
            _db.SaveChanges();
            return newPlant;
        }

        public async Task<Plants?> DeletePlants(Plants plantToDelete)
        {
            if (plantToDelete != null)
            {
                plantToDelete.IsDeleted = true;
                await _db.SaveChangesAsync();
            }

            return plantToDelete;
        }

        public async Task<Plants?> GetPlant(int Plant_Id)
        {
            return await _db.Plants.FindAsync(Plant_Id);
        }

        public async Task<List<Plants>> GetPlants()
        {
            return await _db.Plants.ToListAsync();
        }

        public async Task<Plants?> UpdatePlants(int Plant_Id, string Plant_Name, string Specie, float Min_PH, float Max_PH, float Requirement_Liters)
        {
            Plants? plantToUpdate = await GetPlant(Plant_Id);

            if (plantToUpdate != null)
            {
                plantToUpdate.Plant_Name = Plant_Name;
                plantToUpdate.Specie = Specie;
                plantToUpdate.Min_PH = Min_PH;
                plantToUpdate.Max_PH = Max_PH;
                plantToUpdate.Requirement_Liters = Requirement_Liters;

                await _db.SaveChangesAsync();
            }

            return plantToUpdate;
        }
    }
}
