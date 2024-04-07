using Irrigation_Management.Models;
using Irrigation_Management.Repository;

namespace Irrigation_Management.Services
{
    public interface IAchievementsService
    {
        Task<List<Achievements>> GetAll();
        Task<Achievements?> GetAchievement(int achievementId);
        Task<Achievements> CreateAchievement(string achievementName, string achievementDescription, int achievementStatus);
        Task<Achievements?> UpdateAchievement(int achievementId, string achievementName, string achievementDescription, int achievementStatus);
        Task<Achievements?> DeleteAchievement(int achievementId);
    }

    public class AchievementsService : IAchievementsService
    {
        public readonly IAchievementsRepository _achievementsRepository;
        public AchievementsService(AchievementsRepository achievementsRepository)
        {
            _achievementsRepository = achievementsRepository;
        }

        public async Task<Achievements> CreateAchievement(string achievementName, string achievementDescription, int achievementStatus)
        {
            return await _achievementsRepository.CreateAchievement(achievementName, achievementDescription, achievementStatus);
        }

        public async Task<Achievements?> DeleteAchievement(int achievementId)
        {
            return await _achievementsRepository.DeleteAchievement(achievementId);
        }

        public async Task<List<Achievements>> GetAll()
        {
            return await _achievementsRepository.GetAll();
        }

        public async Task<Achievements?> GetAchievement(int achievementId)
        {
            return await _achievementsRepository.GetAchievement(achievementId);
        }

        public async Task<Achievements?> UpdateAchievement(int achievementId, string achievementName = null, string achievementDescription = null, int achievementStatus = -1)
        {
            Achievements? achievementToUpdate = await _achievementsRepository.GetAchievement(achievementId);

            if (achievementToUpdate != null)
            {
                if (achievementName == null) { achievementName = achievementToUpdate.Achievement_Name; }
                if (achievementDescription == null) { achievementDescription = achievementToUpdate.Achievement_Description; }
                if (achievementStatus == -1) { achievementStatus = achievementToUpdate.Achievement_Status; }

                await _achievementsRepository.UpdateAchievement(achievementId, achievementName, achievementDescription, achievementStatus);
            }

            return achievementToUpdate;
        }
    }
}
