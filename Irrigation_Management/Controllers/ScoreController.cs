using Irrigation_Management.Models;
using Irrigation_Management.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Irrigation_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        private readonly IScoreService _scoreService;

        public ScoreController(IScoreService scoreService)
        {
            _scoreService = scoreService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Score>>> GetAll()
        {
            return Ok(await _scoreService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Score>> GetScore(int id)
        {
            var user = await _scoreService.GetScore(id);
            if (user == null)
            {
                return BadRequest("Score not found");
            }

            return Ok(user);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Score>> UpdateScore(int id, decimal? successRate, decimal? waterSaved, decimal? total)
        {
            var user = await _scoreService.GetScore(id);
            if (user == null)
            {
                return BadRequest("Score not found");
            }

            return Ok(await _scoreService.UpdateScore(id, successRate, waterSaved, total));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Score>> DeleteScore(int id)
        {
            var user = await _scoreService.GetScore(id);
            if (user == null)
            {
                return BadRequest("Score not found");
            }
            return Ok(await _scoreService.DeleteScore(id));
        }

        [HttpPost]
        public async Task<ActionResult<Score>> CreateScore(decimal? successRate, decimal? waterSaved, decimal? total)
        {
            return await _scoreService.CreateScore(successRate, waterSaved, total);
        }
    }
}
