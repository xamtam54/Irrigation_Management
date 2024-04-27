using Irrigation_Management.Context;
using Irrigation_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Irrigation_Management.Repository
{
    public interface IIrrigationProgramsRepository
    {
        Task<List<Irrigation_Programs>> GetAll();
        Task<Irrigation_Programs?> GetIrrigationProgram(int Irrigation_Program_Id);
        Task<Irrigation_Programs> CreateIrrigationProgram(TimeOnly Start_Hour, TimeOnly End_Hour, int Irrigations_Per_Week, int Area_Id);
        Task<Irrigation_Programs?> UpdateIrrigationProgram(int Irrigation_Program_Id, TimeOnly Start_Hour, TimeOnly End_Hour, int Irrigations_Per_Week, int Area_Id);
        Task<Irrigation_Programs?> DeleteIrrigationProgram(Irrigation_Programs irrigationProgramToDelete);
    }

    public class IrrigationProgramsRepository : IIrrigationProgramsRepository
    {
        private readonly ManagementDBContext _db;

        public IrrigationProgramsRepository(ManagementDBContext db)
        {
            _db = db;
        }

        public async Task<List<Irrigation_Programs>> GetAll()
        {
            return await _db.Irrigation_Programs.ToListAsync();
        }

        public async Task<Irrigation_Programs?> GetIrrigationProgram(int Irrigation_Program_Id)
        {
            return await _db.Irrigation_Programs.FindAsync(Irrigation_Program_Id);
        }

        public async Task<Irrigation_Programs> CreateIrrigationProgram(TimeOnly Start_Hour, TimeOnly End_Hour, int Irrigations_Per_Week, int Area_Id)
        {
            Irrigation_Programs newIrrigationProgram = new Irrigation_Programs
            {
                Start_Hour = Start_Hour,
                End_Hour = End_Hour,
                Irrigations_Per_Week = Irrigations_Per_Week,
                Area_Id = Area_Id
            };

            await _db.Irrigation_Programs.AddAsync(newIrrigationProgram);
            await _db.SaveChangesAsync();
            return newIrrigationProgram;
        }

        public async Task<Irrigation_Programs?> UpdateIrrigationProgram(int Irrigation_Program_Id, TimeOnly Start_Hour, TimeOnly End_Hour, int Irrigations_Per_Week, int Area_Id)
        {
            Irrigation_Programs? irrigationProgramToUpdate = await GetIrrigationProgram(Irrigation_Program_Id);

            if (irrigationProgramToUpdate != null)
            {
                irrigationProgramToUpdate.Start_Hour = Start_Hour;
                irrigationProgramToUpdate.End_Hour = End_Hour;
                irrigationProgramToUpdate.Irrigations_Per_Week = Irrigations_Per_Week;
                irrigationProgramToUpdate.Area_Id = Area_Id;

                await _db.SaveChangesAsync();
            }

            return irrigationProgramToUpdate;
        }

        public async Task<Irrigation_Programs?> DeleteIrrigationProgram(Irrigation_Programs irrigationProgramToDelete)
        {
            if (irrigationProgramToDelete != null)
            {
                irrigationProgramToDelete.IsDeleted = true;
                await _db.SaveChangesAsync();
            }

            return irrigationProgramToDelete;
        }

    }
}
