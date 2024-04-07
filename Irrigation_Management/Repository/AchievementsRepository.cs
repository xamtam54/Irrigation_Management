using Irrigation_Management.Context;
using Irrigation_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Irrigation_Management.Repository
{
    public interface IAchievementsRepository
    {
        Task<List<Achievements>> GetAll();
        Task<Achievements?> GetAchievement(int achievementId);
        Task<Achievements> CreateAchievement(string achievementName, string achievementDescription, int achievementStatus);
        Task<Achievements?> UpdateAchievement(int achievementId, string achievementName, string achievementDescription, int achievementStatus);
        Task<Achievements?> DeleteAchievement(int achievementId);
    }

    public class AchievementsRepository : IAchievementsRepository
    {
        private readonly ManagementDBContext _db;
        public AchievementsRepository(ManagementDBContext db)
        {
            _db = db;
        }

        public async Task<List<Achievements>> GetAll()
        {
            return await _db.Achievements.ToListAsync();
        }

        public async Task<Achievements?> GetAchievement(int achievementId)
        {
            return await _db.Achievements.FindAsync(achievementId);
        }

        public async Task<Achievements> CreateAchievement(string achievementName, string achievementDescription, int achievementStatus)
        {
            Achievements newAchievement = new Achievements
            {
                Achievement_Name = achievementName,
                Achievement_Description = achievementDescription,
                Achievement_Status = achievementStatus
            };

            await _db.Achievements.AddAsync(newAchievement);
            await _db.SaveChangesAsync();
            return newAchievement;
        }

        public async Task<Achievements?> UpdateAchievement(int achievementId, string achievementName, string achievementDescription, int achievementStatus)
        {
            Achievements? achievementToUpdate = await GetAchievement(achievementId);

            if (achievementToUpdate != null)
            {
                achievementToUpdate.Achievement_Name = achievementName;
                achievementToUpdate.Achievement_Description = achievementDescription;
                achievementToUpdate.Achievement_Status = achievementStatus;

                await _db.SaveChangesAsync();
            }

            return achievementToUpdate;
        }

        public async Task<Achievements?> DeleteAchievement(int achievementId)
        {
            Achievements? achievementToDelete = await GetAchievement(achievementId);

            if (achievementToDelete != null)
            {
                _db.Achievements.Remove(achievementToDelete);
                await _db.SaveChangesAsync();
            }

            return achievementToDelete;
        }
    }
}
