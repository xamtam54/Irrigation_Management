using Irrigation_Management.Context;
using Irrigation_Management.Models;
using Irrigation_Management.Repository;
using Microsoft.EntityFrameworkCore;

namespace Irrigation_Management.Services
{
    public interface IIrrigationProgramsService
    {
        Task<List<Irrigation_Programs>> GetAll();
        Task<Irrigation_Programs?> GetIrrigationProgram(int Irrigation_Program_Id);
        Task<Irrigation_Programs> CreateIrrigationProgram(TimeOnly Start_Hour, TimeOnly End_Hour, int Irrigations_Per_Week, int Area_Id);
        Task<Irrigation_Programs?> UpdateIrrigationProgram(int Irrigation_Program_Id, TimeOnly? Start_Hour, TimeOnly? End_Hour, int? Irrigations_Per_Week, int? Area_Id);
        Task<Irrigation_Programs?> DeleteIrrigationProgram(int Irrigation_Program_Id);
    }

    public class IrrigationProgramsService : IIrrigationProgramsService
    {
        private readonly IIrrigationProgramsRepository _irrigationProgramsRepository;

        public IrrigationProgramsService(IIrrigationProgramsRepository irrigationProgramsRepository)
        {
            _irrigationProgramsRepository = irrigationProgramsRepository;
        }

        public async Task<List<Irrigation_Programs>> GetAll()
        {
            return await _irrigationProgramsRepository.GetAll();
        }

        public async Task<Irrigation_Programs?> GetIrrigationProgram(int Irrigation_Program_Id)
        {
            return await _irrigationProgramsRepository.GetIrrigationProgram(Irrigation_Program_Id);
        }

        public async Task<Irrigation_Programs> CreateIrrigationProgram(TimeOnly Start_Hour, TimeOnly End_Hour, int Irrigations_Per_Week, int Area_Id)
        {
            return await _irrigationProgramsRepository.CreateIrrigationProgram(Start_Hour, End_Hour, Irrigations_Per_Week, Area_Id);
        }

        public async Task<Irrigation_Programs?> UpdateIrrigationProgram(int Irrigation_Program_Id, TimeOnly? Start_Hour = default, TimeOnly? End_Hour = default, int? Irrigations_Per_Week = -1, int? Area_Id = -1)
        {
            Irrigation_Programs? irrigationProgramToUpdate = await _irrigationProgramsRepository.GetIrrigationProgram(Irrigation_Program_Id);

            if (irrigationProgramToUpdate != null)
            {
                if (Start_Hour != default) { irrigationProgramToUpdate.Start_Hour = (TimeOnly)Start_Hour; }
                if (End_Hour != default) { irrigationProgramToUpdate.End_Hour = (TimeOnly)End_Hour; }
                if (Irrigations_Per_Week != -1) { irrigationProgramToUpdate.Irrigations_Per_Week = (int)Irrigations_Per_Week; }
                if (Area_Id != -1) { irrigationProgramToUpdate.Area_Id = (int)Area_Id; }

                return await _irrigationProgramsRepository.UpdateIrrigationProgram(Irrigation_Program_Id, irrigationProgramToUpdate.Start_Hour, irrigationProgramToUpdate.End_Hour, irrigationProgramToUpdate.Irrigations_Per_Week, irrigationProgramToUpdate.Area_Id);
            }

            return irrigationProgramToUpdate;
        }

        public async Task<Irrigation_Programs?> DeleteIrrigationProgram(int Irrigation_Program_Id)
        {
            Irrigation_Programs? program = await _irrigationProgramsRepository.GetIrrigationProgram(Irrigation_Program_Id);

            if (program != null)
            {
                program.IsDeleted = true;
                // program.Date = DateTime.Now;
                return await _irrigationProgramsRepository.DeleteIrrigationProgram(program);
            }

            return null;
        }
    }
}
