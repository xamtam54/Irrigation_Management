using Irrigation_Management.Models;
using Irrigation_Management.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Irrigation_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Sensor_DataController : ControllerBase
    {
        private readonly ISensorDataService _sensorDataService;

        public Sensor_DataController(ISensorDataService sensorDataService)
        {
            _sensorDataService = sensorDataService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Sensor_Data>>> GetAll()
        {
            return Ok(await _sensorDataService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sensor_Data>> GetSensorData(int id)
        {
            var user = await _sensorDataService.GetSensorData(id);
            if (user == null)
            {
                return BadRequest("Sensor_Data not found");
            }

            return Ok(user);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Sensor_Data>> UpdateSensorData(int id, [FromBody] Sensor_Data model)
        {
            var sensorData = await _sensorDataService.GetSensorData(id);
            if (sensorData == null)
            {
                return BadRequest("Sensor_Data not found");
            }

            return Ok(await _sensorDataService.UpdateSensorData(id, model.Date_Time, model.Data, model.Sensor_Id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Sensor_Data>> DeleteSensorData(int id)
        {
            var sensorData = await _sensorDataService.GetSensorData(id);
            if (sensorData == null)
            {
                return BadRequest("Sensor_Data not found");
            }
            return Ok(await _sensorDataService.DeleteSensorData(id));
        }

        [HttpPost]
        public async Task<ActionResult<Sensor_Data>> CreateSensorData([FromBody] Sensor_Data model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _sensorDataService.CreateSensorData(model.Date_Time, model.Data, model.Sensor_Id);
        }

    }
}
