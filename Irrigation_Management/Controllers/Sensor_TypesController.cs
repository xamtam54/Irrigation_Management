using Irrigation_Management.Models;
using Irrigation_Management.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Irrigation_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Sensor_TypesController : ControllerBase
    {

        private readonly ISensorTypesService _sensorTypesService;

        public Sensor_TypesController(ISensorTypesService sensorTypesService)
        {
            _sensorTypesService = sensorTypesService;
        }


        [HttpGet]
        public async Task<ActionResult<List<Sensor_Types>>> GetAll()
        {
            return Ok(await _sensorTypesService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sensor_Types>> GetSensorType(int id)
        {
            var user = await _sensorTypesService.GetSensorType(id);
            if (user == null)
            {
                return BadRequest("Sensor_Types not found");
            }

            return Ok(user);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Sensor_Types>> UpdateSensorType(int id, [FromBody] Sensor_Types model)
        {
            var sensorType = await _sensorTypesService.GetSensorType(id);
            if (sensorType == null)
            {
                return BadRequest("Sensor_Types not found");
            }

            return Ok(await _sensorTypesService.UpdateSensorType(id, model.Sensor_Type, model.Description, model.Measure_Unit));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Sensor_Types>> DeleteSensorType(int id)
        {
            var sensorType = await _sensorTypesService.GetSensorType(id);
            if (sensorType == null)
            {
                return BadRequest("Sensor_Types not found");
            }
            return Ok(await _sensorTypesService.DeleteSensorType(id));
        }

        [HttpPost]
        public async Task<ActionResult<Sensor_Types>> CreateSensorType([FromBody] Sensor_Types model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _sensorTypesService.CreateSensorType(model.Sensor_Type, model.Description, model.Measure_Unit);
        }

    }
}
