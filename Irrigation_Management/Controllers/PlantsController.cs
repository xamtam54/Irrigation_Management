using Irrigation_Management.Models;
using Irrigation_Management.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Irrigation_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantsController : ControllerBase
    {
        private readonly IPlantsService _plantsService;

        public PlantsController(IPlantsService plantsService)
        {
            _plantsService = plantsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Plants>>> GetAll()
        {
            return Ok(await _plantsService.GetPlants());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Plants>> GetPlant(int id)
        {
            var user = await _plantsService.GetPlant(id);
            if (user == null)
            {
                return BadRequest("Plants not found");
            }

            return Ok(user);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Plants>> UpdatePlants(int id, [FromBody] Plants model)
        {
            var plant = await _plantsService.GetPlant(id);
            if (plant == null)
            {
                return BadRequest("Plants not found");
            }

            return Ok(await _plantsService.UpdatePlants(id, model.Plant_Name, model.Specie, model.Min_PH, model.Max_PH, model.Requirement_Liters));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Plants>> DeletePlants(int id)
        {
            var plant = await _plantsService.GetPlant(id);
            if (plant == null)
            {
                return BadRequest("Plants not found");
            }
            return Ok(await _plantsService.DeletePlants(id));
        }

        [HttpPost]
        public async Task<ActionResult<Plants>> CreatePlants([FromBody] Plants model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _plantsService.CreatePlants(model.Plant_Name, model.Specie, model.Min_PH, model.Max_PH, model.Requirement_Liters);
        }

    }
}
