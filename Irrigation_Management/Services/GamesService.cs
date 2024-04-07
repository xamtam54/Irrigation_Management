using Irrigation_Management.Models;
using Irrigation_Management.Repository;

namespace Irrigation_Management.Services
{
    public interface IGamesService
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

    public class GamesService : IGamesService
    {
        private readonly IGamesRepository _gamesRepository;

        public GamesService(GamesRepository gamesRepository)
        {
            _gamesRepository = gamesRepository;
        }

        public async Task<Games> CreateGame(int userId, int scoreId, int? stage = null, decimal? endScore = null)
        {
            return await _gamesRepository.CreateGame(userId, scoreId, stage, endScore);
        }

        public async Task<Games?> DeleteGame(int gameId)
        {
            return await _gamesRepository.DeleteGame(gameId);
        }

        public async Task<List<Games>> GetAll()
        {
            return await _gamesRepository.GetAll();
        }

        public async Task<Games?> GetGame(int gameId)
        {
            return await _gamesRepository.GetGame(gameId);
        }

        public async Task<Games?> UpdateGame(int gameId, int? stage = null, decimal? endScore = null)
        {
            Games? gameToUpdate = await GetGame(gameId);

            if (gameToUpdate != null)
            {
                if (stage != null) { gameToUpdate.Stage = stage; }
                if (endScore != null) { gameToUpdate.End_Score = endScore; }

                await _gamesRepository.UpdateGame(gameId, stage, endScore);
            }

            return gameToUpdate;
        }

        //------------------------------------------------------------------------------------------
        public async Task<Allocation_Systems> CreateAllocationSystem(int gameId, int systemId)
        {
            return await _gamesRepository.CreateAllocationSystem(gameId, systemId);
        }

        public async Task<Allocation_Systems?> DeleteAllocationSystem(int gameId, int systemId)
        {
            return await _gamesRepository.DeleteAllocationSystem(gameId, systemId);
        }
    }
}
