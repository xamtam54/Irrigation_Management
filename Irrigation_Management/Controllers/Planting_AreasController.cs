using Irrigation_Management.Models;
using Irrigation_Management.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Irrigation_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Planting_AreasController : ControllerBase
    {
        private readonly IPlanting_AreasService _planting_AreasService;

        public Planting_AreasController(IPlanting_AreasService planting_AreasService)
        {
            _planting_AreasService = planting_AreasService;
        }


        [HttpGet]
        public async Task<ActionResult<List<Planting_Areas>>> GetPlanting_Areas()
        {
            return Ok(await _planting_AreasService.GetPlanting_Areas());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Planting_Areas>> GetPlanting_Area(int id)
        {
            var user = await _planting_AreasService.GetPlanting_Area(id);
            if (user == null)
            {
                return BadRequest("Planting_Areas not found");
            }

            return Ok(user);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Planting_Areas>> UpdatePlanting_Areas(int id, int Crop_Status_Id, int Plant_Id)
        {
            var user = await _planting_AreasService.GetPlanting_Area(id);
            if (user == null)
            {
                return BadRequest("Planting_Areas not found");
            }

            return Ok(await _planting_AreasService.UpdatePlanting_Areas(id, Crop_Status_Id, Plant_Id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Planting_Areas>> DeletePlanting_Areas(int id)
        {
            var user = await _planting_AreasService.GetPlanting_Area(id);
            if (user == null)
            {
                return BadRequest("Planting_Areas not found");
            }
            return Ok(await _planting_AreasService.DeletePlanting_Areas(id));
        }

        [HttpPost]
        public async Task<ActionResult<Planting_Areas>> CreatePlanting_Areas(int Crop_Status_Id, int Plant_Id)
        {
            return await _planting_AreasService.CreatePlanting_Areas(Crop_Status_Id, Plant_Id);
        }
    }
}
