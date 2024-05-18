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
        public async Task<ActionResult<Sensors>> UpdateSensor(int id, [FromBody] Sensors model)
        {
            var sensor = await _sensorsService.GetSensor(id);
            if (sensor == null)
            {
                return BadRequest("Sensors not found");
            }

            return Ok(await _sensorsService.UpdateSensor(id, model.Sensor_Type_Id, model.Device_Id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Sensors>> DeleteSensor(int id)
        {
            var sensor = await _sensorsService.GetSensor(id);
            if (sensor == null)
            {
                return BadRequest("Sensors not found");
            }
            return Ok(await _sensorsService.DeleteSensor(id));
        }

        [HttpPost]
        public async Task<ActionResult<Sensors>> CreateSensor([FromBody] Sensors model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _sensorsService.CreateSensor(model.Sensor_Type_Id, model.Device_Id);
        }

    }
}
