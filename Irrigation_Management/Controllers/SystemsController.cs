using Irrigation_Management.Models;
using Irrigation_Management.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Irrigation_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemsController : ControllerBase
    {
        private readonly ISystemsService _systemsService;

        public SystemsController(ISystemsService systemsService)
        {
            _systemsService = systemsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Systems>>> GetAll()
        {
            return Ok(await _systemsService.GetSystems());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Systems>> GetSystem(int id)
        {
            var user = await _systemsService.GetSystem(id);
            if (user == null)
            {
                return BadRequest("Systems not found");
            }

            return Ok(user);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Systems>> UpdateSystem(int id, [FromBody] Systems model)
        {
            var system = await _systemsService.GetSystem(id);
            if (system == null)
            {
                return BadRequest("Systems not found");
            }

            return Ok(await _systemsService.UpdateSystem(id, model.Systems_Name));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Systems>> DeleteSystem(int id)
        {
            var system = await _systemsService.GetSystem(id);
            if (system == null)
            {
                return BadRequest("Systems not found");
            }
            return Ok(await _systemsService.DeleteSystem(id));
        }

        [HttpPost]
        public async Task<ActionResult<Systems>> CreateSystem([FromBody] Systems model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _systemsService.CreateSystem(model.Systems_Name);
        }

    }
}
