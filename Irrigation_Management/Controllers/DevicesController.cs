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
        public async Task<ActionResult<Devices>> UpdateDevice(int id, string Device_Name, decimal Device_Price, int Device_Enabled, int System_Id, int? Area_Id)
        {
            var user = await _devicesService.GetDevice(id);
            if (user == null)
            {
                return BadRequest("Devices not found");
            }

            return Ok(await _devicesService.UpdateDevice(id, Device_Name, Device_Price, Device_Enabled, System_Id, Area_Id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Devices>> DeleteDevice(int id)
        {
            var user = await _devicesService.GetDevice(id);
            if (user == null)
            {
                return BadRequest("Devices not found");
            }
            return Ok(await _devicesService.DeleteDevice(id));
        }

        [HttpPost]
        public async Task<ActionResult<Devices>> CreateDevice(string Device_Name, decimal Device_Price, int Device_Enabled, int System_Id, int? Area_Id)
        {
            return await _devicesService.CreateDevice( Device_Name, Device_Price, Device_Enabled, System_Id, Area_Id);
        }
    }
}
