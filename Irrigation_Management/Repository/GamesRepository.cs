using Irrigation_Management.Context;
using Irrigation_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Irrigation_Management.Repository
{
    public interface IGamesRepository
    {
        Task<List<Games>> GetAll();
        Task<Games?> GetGame(int gameId);
        Task<Games> CreateGame(int userId, int scoreId, int? stage = null, decimal? endScore = null);
        Task<Games?> UpdateGame(int gameId, int? stage = null, decimal? endScore = null);
        Task<Games?> DeleteGame(int gameId);
        //----------------------------------------------------------
        Task<Allocation_Systems> CreateAllocationSystem(int gameId, int systemId);
        Task<Allocation_Systems?> DeleteAllocationSystem(int gameId, int systemId);

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

        public async Task<Games> CreateGame(int userId, int scoreId, int? stage = null, decimal? endScore = 0.0m)
        {
            Games newGame = new Games
            {
                Users_Id = userId,
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


        public async Task<Games?> DeleteGame(int gameId)
        {
            Games? gameToDelete = await GetGame(gameId);

            if (gameToDelete != null)
            {
                _db.Games.Remove(gameToDelete);
                await _db.SaveChangesAsync();
            }

            return gameToDelete;
        }
        //--------------------------------------------------------------------------------------------

        public async Task<Allocation_Systems> CreateAllocationSystem(int gameId, int systemId)
        {
            var system = await _db.Systems.FindAsync(systemId);
            var game = await _db.Games.FindAsync(gameId);

            if (game == null || system == null)
            {
                throw new InvalidOperationException("The game or system does not exist");
            }

            var existingAllocation = await _db.Allocation_Systems.FirstOrDefaultAsync(a => a.Game_Id == gameId && a.System_Id == systemId);
            if (existingAllocation != null)
            {
                throw new InvalidOperationException("An allocation system for this game and system already exists.");
            }

            var allocationSystem = new Allocation_Systems
            {
                Game_Id = gameId,
                System_Id = systemId
            };

            await _db.Allocation_Systems.AddAsync(allocationSystem);
            await _db.SaveChangesAsync();
            return allocationSystem;
        }

        public async Task<Allocation_Systems?> DeleteAllocationSystem(int gameId, int systemId)
        {
            var allocationSystem = await _db.Allocation_Systems.FirstOrDefaultAsync(a => a.Game_Id == gameId && a.System_Id == systemId);

            if (allocationSystem != null)
            {
                _db.Allocation_Systems.Remove(allocationSystem);
                await _db.SaveChangesAsync();
            }

            return allocationSystem;
        }
    }
}
