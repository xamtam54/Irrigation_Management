using Irrigation_Management.Models;
using Irrigation_Management.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Irrigation_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorsController : ControllerBase
    {
        private readonly ISensorsService _sensorsService;

        public SensorsController(ISensorsService sensorsService)
        {
            _sensorsService = sensorsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Sensors>>> GetAll()
        {
            return Ok(await _sensorsService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sensors>> GetSensor(int id)
        {
            var user = await _sensorsService.GetSensor(id);
            if (user == null)
            {
                return BadRequest("Sensors not found");
            }

            return Ok(user);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Sensors>> UpdateSensor(int id, int Sensor_Type_Id, int Device_Id)
        {
            var user = await _sensorsService.GetSensor(id);
            if (user == null)
            {
                return BadRequest("Sensors not found");
            }

            return Ok(await _sensorsService.UpdateSensor(id, Sensor_Type_Id, Device_Id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Sensors>> DeleteSensor(int id)
        {
            var user = await _sensorsService.GetSensor(id);
            if (user == null)
            {
                return BadRequest("Sensors not found");
            }
            return Ok(await _sensorsService.DeleteSensor(id));
        }

        [HttpPost]
        public async Task<ActionResult<Sensors>> CreateSensor(int Sensor_Type_Id, int Device_Id)
        {
            return await _sensorsService.CreateSensor(Sensor_Type_Id, Device_Id);
        }
    }
}
