using Irrigation_Management.Models;
using Irrigation_Management.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Irrigation_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AchievementsController : ControllerBase
    {

        private readonly IAchievementsService _achievementsService;

        public AchievementsController(IAchievementsService achievementsService)
        {
            _achievementsService = achievementsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Achievements>>> GetAll()
        {
            return Ok(await _achievementsService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Achievements>> GetAchievement(int id)
        {
            var user = await _achievementsService.GetAchievement(id);
            if (user == null)
            {
                return BadRequest("Achievement not found");
            }

            return Ok(user);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Achievements>> UpdateAchievement(int id, string achievementName, string achievementDescription, int achievementStatus)
        {
            var user = await _achievementsService.GetAchievement(id);
            if (user == null)
            {
                return BadRequest("Achievement not found");
            }

            return Ok(await _achievementsService.UpdateAchievement(id, achievementName, achievementDescription, achievementStatus));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Achievements>> DeleteAchievement(int id)
        {
            var user = await _achievementsService.GetAchievement(id);
            if (user == null)
            {
                return BadRequest("Achievement not found");
            }
            return Ok(await _achievementsService.DeleteAchievement(id));
        }

        [HttpPost]
        public async Task<ActionResult<Achievements>> CreateAchievement(string achievementName, string achievementDescription, int achievementStatus)
        {
            return await _achievementsService.CreateAchievement( achievementName, achievementDescription, achievementStatus);
        }

    }
}
