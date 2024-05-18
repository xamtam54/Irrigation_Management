using Irrigation_Management.Models;
using Irrigation_Management.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Irrigation_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly IDevicesService _devicesService;

        public DevicesController(IDevicesService devicesService)
        {
            _devicesService = devicesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Devices>>> GetDevices()
        {
            return Ok(await _devicesService.GetDevices());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Devices>> GetDevice(int id)
        {
            var user = await _devicesService.GetDevice(id);
            if (user == null)
            {
                return BadRequest("Devices not found");
            }

            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Devices>> UpdateDevice(int id, [FromBody] Devices model)
        {
            var device = await _devicesService.GetDevice(id);
            if (device == null)
            {
                return BadRequest("Device not found");
            }

            return Ok(await _devicesService.UpdateDevice(id, model.Device_Name, model.Device_Price, model.Device_Enabled, model.System_Id, model.Area_Id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Devices>> DeleteDevice(int id)
        {
            var device = await _devicesService.GetDevice(id);
            if (device == null)
            {
                return BadRequest("Device not found");
            }
            return Ok(await _devicesService.DeleteDevice(id));
        }

        [HttpPost]
        public async Task<ActionResult<Devices>> CreateDevice([FromBody] Devices model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _devicesService.CreateDevice(model.Device_Name, model.Device_Price, model.Device_Enabled, model.System_Id, model.Area_Id);
        }

    }
}
