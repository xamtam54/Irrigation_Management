using Irrigation_Management.Models;
using Irrigation_Management.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Irrigation_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Irrigation_ProgramsController : ControllerBase
    {
        private readonly IIrrigationProgramsService _irrigationProgramsService;

        public Irrigation_ProgramsController(IIrrigationProgramsService irrigationProgramsService)
        {
            _irrigationProgramsService = irrigationProgramsService;
        }


        [HttpGet]
        public async Task<ActionResult<List<Irrigation_Programs>>> GetAll()
        {
            return Ok(await _irrigationProgramsService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Irrigation_Programs>> GetIrrigationProgram(int id)
        {
            var user = await _irrigationProgramsService.GetIrrigationProgram(id);
            if (user == null)
            {
                return BadRequest("Irrigation_Programs not found");
            }

            return Ok(user);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Irrigation_Programs>> UpdateIrrigationProgram(int id, TimeOnly Start_Hour, TimeOnly End_Hour, int Irrigations_Per_Week, int Area_Id)
        {
            var user = await _irrigationProgramsService.GetIrrigationProgram(id);
            if (user == null)
            {
                return BadRequest("Irrigation_Programs not found");
            }

            return Ok(await _irrigationProgramsService.UpdateIrrigationProgram(id, Start_Hour, End_Hour, Irrigations_Per_Week, Area_Id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Irrigation_Programs>> DeleteIrrigationProgram(int id)
        {
            var user = await _irrigationProgramsService.GetIrrigationProgram(id);
            if (user == null)
            {
                return BadRequest("Irrigation_Programs not found");
            }
            return Ok(await _irrigationProgramsService.DeleteIrrigationProgram(id));
        }

        [HttpPost]
        public async Task<ActionResult<Irrigation_Programs>> CreateIrrigationProgram(TimeOnly Start_Hour, TimeOnly End_Hour, int Irrigations_Per_Week, int Area_Id)
        {
            return await _irrigationProgramsService.CreateIrrigationProgram(Start_Hour, End_Hour, Irrigations_Per_Week, Area_Id);
        }
    }
}
