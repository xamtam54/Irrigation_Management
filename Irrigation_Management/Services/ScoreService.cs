using Irrigation_Management.Models;
using Irrigation_Management.Repository;

namespace Irrigation_Management.Services
{
    public interface IScoreService
    {
        Task<List<Score>> GetAll();
        Task<Score?> GetScore(int scoreId);
        Task<Score> CreateScore(decimal? successRate, decimal? waterSaved, decimal? total);
        Task<Score?> UpdateScore(int scoreId, decimal? successRate, decimal? waterSaved, decimal? total);
        Task<Score?> DeleteScore(int scoreId);
    }

    public class ScoreService : IScoreService
    {
        private readonly IScoreRepository _scoreRepository;

        public ScoreService(ScoreRepository scoreRepository)
        {
            _scoreRepository = scoreRepository;
        }

        public async Task<Score> CreateScore(decimal? successRate, decimal? waterSaved, decimal? total)
        {
            return await _scoreRepository.CreateScore(successRate, waterSaved, total);
        }

        public async Task<Score?> DeleteScore(int scoreId)
        {
            return await _scoreRepository.DeleteScore(scoreId);
        }

        public async Task<List<Score>> GetAll()
        {
            return await _scoreRepository.GetAll();
        }

        public async Task<Score?> GetScore(int scoreId)
        {
            return await _scoreRepository.GetScore(scoreId);
        }

        public async Task<Score?> UpdateScore(int scoreId, decimal? successRate = null, decimal? waterSaved = null, decimal? total = null)
        {
            Score? scoreToUpdate = await _scoreRepository.GetScore(scoreId);

            if (scoreToUpdate != null)
            {
                if (successRate == null) { successRate = scoreToUpdate.Success_Rate; }
                if (waterSaved == null) { waterSaved = scoreToUpdate.Water_Saved; }
                if (total == null) { total = scoreToUpdate.Total; }

                await _scoreRepository.UpdateScore(scoreId, successRate, waterSaved, total);
            }

            return scoreToUpdate;
        }
    }
}
