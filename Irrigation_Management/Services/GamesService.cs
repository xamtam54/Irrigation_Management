using Irrigation_Management.Models;
using Irrigation_Management.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Irrigation_Management.Services
{
    public interface IGamesService
    {
        Task<List<Games>> GetAll();
        Task<Games?> GetGame(int gameId);
        Task<Games> CreateGame(int Achievement_Id, int scoreId, int? stage = null, decimal? endScore = null);
        Task<Games?> UpdateGameAchievementId(int gameId, int? achievementId);
        Task<Games?> DeleteGame(int gameId);
        //----------------------------------------------------------
    }

    public class GamesService : IGamesService
    {
        private readonly IGamesRepository _gamesRepository;

        public GamesService(IGamesRepository gamesRepository)
        {
            _gamesRepository = gamesRepository;
        }

        public async Task<Games> CreateGame(int Achievement_Id, int scoreId, int? stage = null, decimal? endScore = null)
        {
            return await _gamesRepository.CreateGame(Achievement_Id, scoreId, stage, endScore);
        }

        public async Task<Games?> DeleteGame(int gameId)
        {
            Games? game = await _gamesRepository.GetGame(gameId);

            if (game != null)
            {
                game.IsDeleted = true;
                // game.Date = DateTime.Now;
                return await _gamesRepository.DeleteGame(game);
            }

            return null;
        }


        public async Task<List<Games>> GetAll()
        {
            return await _gamesRepository.GetAll();
        }

        public async Task<Games?> GetGame(int gameId)
        {
            return await _gamesRepository.GetGame(gameId);
        }

        public async Task<Games?> UpdateGameAchievementId(int gameId, int? achievementId)
        {
            var updatedGame = await _gamesRepository.UpdateGame(gameId, achievementId);
            return updatedGame;
        }

        //------------------------------------------------------------------------------------------

    }
}
