using Irrigation_Management.Models;
using Irrigation_Management.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Irrigation_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Irrigation_ActuatorsController : ControllerBase
    {
        private readonly IIrrigationActuatorsService _irrigationActuatorsService;

        public Irrigation_ActuatorsController(IIrrigationActuatorsService irrigationActuatorsService)
        {
            _irrigationActuatorsService = irrigationActuatorsService;
        }


        [HttpGet]
        public async Task<ActionResult<List<Irrigation_Actuators>>> GetAll()
        {
            return Ok(await _irrigationActuatorsService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Irrigation_Actuators>> GetIrrigationActuator(int id)
        {
            var user = await _irrigationActuatorsService.GetIrrigationActuator(id);
            if (user == null)
            {
                return BadRequest("Irrigation_Actuators not found");
            }

            return Ok(user);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Irrigation_Actuators>> UpdateIrrigationActuator(int id, int Device_Id, int Irrigation_Actuators_Type_Id)
        {
            var user = await _irrigationActuatorsService.GetIrrigationActuator(id);
            if (user == null)
            {
                return BadRequest("Irrigation_Actuators not found");
            }

            return Ok(await _irrigationActuatorsService.UpdateIrrigationActuator(id, Device_Id, Irrigation_Actuators_Type_Id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Irrigation_Actuators>> DeleteIrrigationActuator(int id)
        {
            var user = await _irrigationActuatorsService.GetIrrigationActuator(id);
            if (user == null)
            {
                return BadRequest("Irrigation_Actuators not found");
            }
            return Ok(await _irrigationActuatorsService.DeleteIrrigationActuator(id));
        }

        [HttpPost]
        public async Task<ActionResult<Irrigation_Actuators>> CreateIrrigationActuator(int Device_Id, int Irrigation_Actuators_Type_Id)
        {
            return await _irrigationActuatorsService.CreateIrrigationActuator(Device_Id, Irrigation_Actuators_Type_Id);
        }
    }
}
