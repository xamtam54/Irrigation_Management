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
        public async Task<ActionResult<Sensor_Data>> UpdateSensorData(int id, DateTime Date_Time, float Data, int Sensor_Id)
        {
            var user = await _sensorDataService.GetSensorData(id);
            if (user == null)
            {
                return BadRequest("Sensor_Data not found");
            }

            return Ok(await _sensorDataService.UpdateSensorData(id, Date_Time, Data, Sensor_Id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Sensor_Data>> DeleteSensorData(int id)
        {
            var user = await _sensorDataService.GetSensorData(id);
            if (user == null)
            {
                return BadRequest("Sensor_Data not found");
            }
            return Ok(await _sensorDataService.DeleteSensorData(id));
        }

        [HttpPost]
        public async Task<ActionResult<Sensor_Data>> CreateSensorData(DateTime Date_Time, float Data, int Sensor_Id)
        {
            return await _sensorDataService.CreateSensorData(Date_Time, Data, Sensor_Id);
        }
    }
}
