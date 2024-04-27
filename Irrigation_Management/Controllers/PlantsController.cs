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
        public async Task<ActionResult<Plants>> UpdatePlants(int id, string Plant_Name, string Specie, float Min_PH, float Max_PH, float Requirement_Liters)
        {
            var user = await _plantsService.GetPlant(id);
            if (user == null)
            {
                return BadRequest("Plants not found");
            }

            return Ok(await _plantsService.UpdatePlants(id, Plant_Name, Specie, Min_PH, Max_PH, Requirement_Liters));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Plants>> DeletePlants(int id)
        {
            var user = await _plantsService.GetPlant(id);
            if (user == null)
            {
                return BadRequest("Plants not found");
            }
            return Ok(await _plantsService.DeletePlants(id));
        }

        [HttpPost]
        public async Task<ActionResult<Plants>> CreatePlants(string Plant_Name, string Specie, float Min_PH, float Max_PH, float Requirement_Liters)
        {
            return await _plantsService.CreatePlants(Plant_Name, Specie, Min_PH, Max_PH, Requirement_Liters);
        }
    }
}
