using Irrigation_Management.Models;
using Irrigation_Management.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Irrigation_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGamesService _gamesService;

        public GamesController(IGamesService gamesService)
        {
            _gamesService = gamesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Games>>> GetAll()
        {
            return Ok(await _gamesService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Games>> GetGame(int id)
        {
            var user = await _gamesService.GetGame(id);
            if (user == null)
            {
                return BadRequest("Game not found");
            }

            return Ok(user);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Games>> UpdateGame(int id, int? stage = null, decimal? endScore = null)
        {
            var user = await _gamesService.GetGame(id);
            if (user == null)
            {
                return BadRequest("Game not found");
            }

            return Ok(await _gamesService.UpdateGame(id, stage , endScore ));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Games>> DeleteGame(int id)
        {
            var user = await _gamesService.GetGame(id);
            if (user == null)
            {
                return BadRequest("Game not found");
            }
            return Ok(await _gamesService.DeleteGame(id));
        }

        [HttpPost]
        public async Task<ActionResult<Games>> CreateGame(int Achievement_Id, int scoreId, int? stage = null, decimal? endScore = null)
        {
            return await _gamesService.CreateGame(Achievement_Id,  scoreId, stage , endScore);
        }

    }
}
