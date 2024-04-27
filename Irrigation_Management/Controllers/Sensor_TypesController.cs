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
        public async Task<ActionResult<Sensor_Types>> UpdateSensorType(int id, string Sensor_Type, string Description, string Measure_Unit)
        {
            var user = await _sensorTypesService.GetSensorType(id);
            if (user == null)
            {
                return BadRequest("Sensor_Types not found");
            }

            return Ok(await _sensorTypesService.UpdateSensorType(id, Sensor_Type, Description, Measure_Unit));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Sensor_Types>> DeleteSensorType(int id)
        {
            var user = await _sensorTypesService.GetSensorType(id);
            if (user == null)
            {
                return BadRequest("Sensor_Types not found");
            }
            return Ok(await _sensorTypesService.DeleteSensorType(id));
        }

        [HttpPost]
        public async Task<ActionResult<Sensor_Types>> CreateSensorType(string Sensor_Type, string Description, string Measure_Unit)
        {
            return await _sensorTypesService.CreateSensorType( Sensor_Type, Description, Measure_Unit);
        }
    }
}
