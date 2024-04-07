using Irrigation_Management.Context;
using Irrigation_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Irrigation_Management.Repository
{
    public interface IScoreRepository
    {
        Task<List<Score>> GetAll();
        Task<Score?> GetScore(int scoreId);
        Task<Score> CreateScore(decimal? successRate, decimal? waterSaved, decimal? total);
        Task<Score?> UpdateScore(int scoreId, decimal? successRate, decimal? waterSaved, decimal? total);
        Task<Score?> DeleteScore(int scoreId);
    }

    public class ScoreRepository : IScoreRepository
    {
        private readonly ManagementDBContext _db;

        public ScoreRepository(ManagementDBContext db)
        {
            _db = db;
        }

        public async Task<List<Score>> GetAll()
        {
            return await _db.Scores.ToListAsync();
        }

        public async Task<Score?> GetScore(int scoreId)
        {
            return await _db.Scores.FindAsync(scoreId);
        }

        public async Task<Score> CreateScore(decimal? successRate, decimal? waterSaved, decimal? total)
        {
            Score newScore = new Score
            {
                Success_Rate = successRate,
                Water_Saved = waterSaved,
                Total = total
            };

            await _db.Scores.AddAsync(newScore);
            await _db.SaveChangesAsync();
            return newScore;
        }

        public async Task<Score?> UpdateScore(int scoreId, decimal? successRate, decimal? waterSaved, decimal? total)
        {
            Score? scoreToUpdate = await GetScore(scoreId);

            if (scoreToUpdate != null)
            {
                scoreToUpdate.Success_Rate = successRate;
                scoreToUpdate.Water_Saved = waterSaved;
                scoreToUpdate.Total = total;

                await _db.SaveChangesAsync();
            }

            return scoreToUpdate;
        }

        public async Task<Score?> DeleteScore(int scoreId)
        {
            Score? scoreToDelete = await GetScore(scoreId);

            if (scoreToDelete != null)
            {
                _db.Scores.Remove(scoreToDelete);
                await _db.SaveChangesAsync();
            }

            return scoreToDelete;
        }
    }
}
