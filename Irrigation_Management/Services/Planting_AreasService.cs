﻿using Irrigation_Management.Models;
using Irrigation_Management.Repository;
using static Azure.Core.HttpHeader;

namespace Irrigation_Management.Services
{
    public interface IPlanting_AreasService
    {
        Task<List<Planting_Areas>> GetPlanting_Areas();
        Task<Planting_Areas?> GetPlanting_Area(int Area_Id);
        Task<Planting_Areas> CreatePlanting_Areas(int Crop_Status_Id, string Area_Name, int Plant_Id);
        Task<Planting_Areas?> UpdatePlanting_Areas(int Area_Id, string Area_Name, int? Crop_Status_Id, int? Plant_Id);
        Task<Planting_Areas?> DeletePlanting_Areas(int Area_Id);
    }
    public class Planting_AreasService : IPlanting_AreasService
    {
        public readonly IPlanting_AreasRepository _planting_AreasRepository;
        public Planting_AreasService(IPlanting_AreasRepository planting_AreasRepository)
        {
            _planting_AreasRepository = planting_AreasRepository;
        }

        public async Task<Planting_Areas> CreatePlanting_Areas(int Crop_Status_Id, string Area_Name, int Plant_Id)
        {
            return await _planting_AreasRepository.CreatePlanting_Areas(Crop_Status_Id, Area_Name, Plant_Id);
        }

        public async Task<Planting_Areas?> DeletePlanting_Areas(int Area_Id)
        {
            Planting_Areas? area = await _planting_AreasRepository.GetPlanting_Area(Area_Id);

            if (area != null)
            {
                area.IsDeleted = true;
                // area.Date = DateTime.Now;
                return await _planting_AreasRepository.DeletePlanting_Areas(area);
            }

            return null;
        }

        public async Task<Planting_Areas?> GetPlanting_Area(int Area_Id)
        {
            return await _planting_AreasRepository.GetPlanting_Area(Area_Id);
        }

        public async Task<List<Planting_Areas>> GetPlanting_Areas()
        {
            return await _planting_AreasRepository.GetPlanting_Areas();
        }

        public async Task<Planting_Areas?> UpdatePlanting_Areas(int Area_Id, string Area_Name, int? Crop_Status_Id = -1, int? Plant_Id = -1)
        {
            Planting_Areas? planting_AreaToUpdate = await _planting_AreasRepository.GetPlanting_Area(Area_Id);

            if (planting_AreaToUpdate != null)
            {
                if (Area_Name == null) { Area_Name = planting_AreaToUpdate.Area_Name; }
                if (Crop_Status_Id == -1) { Crop_Status_Id = planting_AreaToUpdate.Crop_Status_Id; }
                if (Plant_Id == -1) { Plant_Id = planting_AreaToUpdate.Plant_Id; }

                await _planting_AreasRepository.UpdatePlanting_Areas(Area_Id, Area_Name, (int)Crop_Status_Id, (int)Plant_Id);
            }

            return planting_AreaToUpdate;
        }
    }
}
