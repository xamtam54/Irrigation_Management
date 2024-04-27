using Irrigation_Management.Models;
using Irrigation_Management.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Irrigation_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Irrigation_Actuators_TypesController : ControllerBase
    {
        private readonly IIrrigationActuatorsTypesService _irrigationActuatorsTypesService;

        public Irrigation_Actuators_TypesController(IIrrigationActuatorsTypesService irrigationActuatorsTypesService)
        {
            _irrigationActuatorsTypesService = irrigationActuatorsTypesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Irrigation_Actuators_Types>>> GetAll()
        {
            return Ok(await _irrigationActuatorsTypesService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Irrigation_Actuators_Types>> GetIrrigationActuatorType(int id)
        {
            var user = await _irrigationActuatorsTypesService.GetIrrigationActuatorType(id);
            if (user == null)
            {
                return BadRequest("Irrigation_Actuators_Types not found");
            }

            return Ok(user);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Irrigation_Actuators_Types>> UpdateIrrigationActuatorType(int id, string Type_Name, string Description)
        {
            var user = await _irrigationActuatorsTypesService.GetIrrigationActuatorType(id);
            if (user == null)
            {
                return BadRequest("Irrigation_Actuators_Types not found");
            }

            return Ok(await _irrigationActuatorsTypesService.UpdateIrrigationActuatorType(id, Type_Name, Description));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Irrigation_Actuators_Types>> DeleteIrrigationActuatorType(int id)
        {
            var user = await _irrigationActuatorsTypesService.GetIrrigationActuatorType(id);
            if (user == null)
            {
                return BadRequest("Irrigation_Actuators_Types not found");
            }
            return Ok(await _irrigationActuatorsTypesService.DeleteIrrigationActuatorType(id));
        }

        [HttpPost]
        public async Task<ActionResult<Irrigation_Actuators_Types>> CreateIrrigationActuatorType(string Type_Name, string Description)
        {
            return await _irrigationActuatorsTypesService.CreateIrrigationActuatorType(Type_Name, Description);
        }
    }
}
