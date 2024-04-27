using Irrigation_Management.Models;
using Irrigation_Management.Repository;

namespace Irrigation_Management.Services
{
    public interface IPlantsService
    {
        Task<List<Plants>> GetPlants();
        Task<Plants?> GetPlant(int Plant_Id);
        Task<Plants> CreatePlants(string Plant_Name, string Specie, float Min_PH, float Max_PH, float Requirement_Liters);
        Task<Plants?> UpdatePlants(int Plant_Id, string? Plant_Name, string? Specie, float? Min_PH, float? Max_PH, float? Requirement_Liters);
        Task<Plants?> DeletePlants(int Plant_Id);
    }
    public class PlantsService : IPlantsService
    {
        public readonly IPlantsRepository _plantsRepository;
        public PlantsService(IPlantsRepository plantsRepository)
        {
            _plantsRepository = plantsRepository;
        }

        public async Task<List<Plants>> GetPlants()
        {
            return await _plantsRepository.GetPlants();
        }

        public async Task<Plants?> GetPlant(int Plant_Id)
        {
            return await _plantsRepository.GetPlant(Plant_Id);
        }

        public async Task<Plants> CreatePlants(string Plant_Name, string Specie, float Min_PH, float Max_PH, float Requirement_Liters)
        {
            return await _plantsRepository.CreatePlants(Plant_Name, Specie, Min_PH, Max_PH, Requirement_Liters);
        }

        public async Task<Plants?> UpdatePlants(int Plant_Id, string? Plant_Name = null, string? Specie = null, float? Min_PH = -1, float? Max_PH = -1, float? Requirement_Liters = -1)
        {
            Plants? plantToUpdate = await _plantsRepository.GetPlant(Plant_Id);

            if (plantToUpdate != null)
            {
                if (Plant_Name != null) { plantToUpdate.Plant_Name = Plant_Name; }
                if (Specie != null) { plantToUpdate.Specie = Specie; }
                if (Min_PH != -1) { plantToUpdate.Min_PH = (float)Min_PH; }
                if (Max_PH != -1) { plantToUpdate.Max_PH = (float)Max_PH; }
                if (Requirement_Liters != -1) { plantToUpdate.Requirement_Liters = (float)Requirement_Liters; }

                await _plantsRepository.UpdatePlants(Plant_Id, plantToUpdate.Plant_Name, plantToUpdate.Specie, plantToUpdate.Min_PH, plantToUpdate.Max_PH, plantToUpdate.Requirement_Liters);
            }

            return plantToUpdate;
        }

        public async Task<Plants?> DeletePlants(int Plant_Id)
        {
            Plants? plant = await _plantsRepository.GetPlant(Plant_Id);

            if (plant != null)
            {
                plant.IsDeleted = true;
                // plant.Date = DateTime.Now;
                return await _plantsRepository.DeletePlants(plant);
            }

            return null;
        }
    }
}
