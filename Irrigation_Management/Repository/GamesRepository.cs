using Irrigation_Management.Context;
using Irrigation_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Irrigation_Management.Repository
{
    public interface IGamesRepository
    {
        Task<List<Games>> GetAll();
        Task<Games?> GetGame(int gameId);
        Task<Games> CreateGame(int Achievement_Id, int scoreId, int? stage = null, decimal? endScore = null);
        Task<Games?> UpdateGame(int gameId, int? stage = null, decimal? endScore = null);
        Task<Games?> DeleteGame(Games gameToDelete);
        //----------------------------------------------------------

    }

    public class GamesRepository : IGamesRepository
    {
        private readonly ManagementDBContext _db;

        public GamesRepository(ManagementDBContext db)
        {
            _db = db;
        }

        public async Task<List<Games>> GetAll()
        {
            return await _db.Games.ToListAsync();
        }

        public async Task<Games?> GetGame(int gameId)
        {
            return await _db.Games.FindAsync(gameId);
        }

        public async Task<Games> CreateGame(int Achievement_Id, int scoreId, int? stage = null, decimal? endScore = 0.0m)
        {
            Games newGame = new Games
            {
                Achievement_Id = Achievement_Id,
                Score_Id = scoreId,
                Stage = stage,
                End_Score = endScore
            };

            await _db.Games.AddAsync(newGame);
            await _db.SaveChangesAsync();
            return newGame;
        }

        public async Task<Games?> UpdateGame(int gameId, int? stage = null, decimal? endScore = null)
        {
            Games? gameToUpdate = await GetGame(gameId);

            if (gameToUpdate != null)
            {
                gameToUpdate.Stage = stage;
                gameToUpdate.End_Score = endScore;

                await _db.SaveChangesAsync();
            }

            return gameToUpdate;
        }


        public async Task<Games?> DeleteGame(Games gameToDelete)
        {
            if (gameToDelete != null)
            {
                gameToDelete.IsDeleted = true;
                await _db.SaveChangesAsync();
            }

            return gameToDelete;
        }
        
    }
}
