using Irrigation_Management.Models;
using Irrigation_Management.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Irrigation_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Water_ManagementController : ControllerBase
    {
        private readonly IWaterManagementService _waterManagementService;

        public Water_ManagementController(IWaterManagementService waterManagementService)
        {
            _waterManagementService = waterManagementService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Water_Management>>> GetAll()
        {
            return Ok(await _waterManagementService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Water_Management>> GetWaterManagement(int id)
        {
            var user = await _waterManagementService.GetWaterManagement(id);
            if (user == null)
            {
                return BadRequest("Water_Management not found");
            }

            return Ok(user);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Water_Management>> UpdateWaterManagement(int id, [FromBody] Water_Management model)
        {
            var waterManagement = await _waterManagementService.GetWaterManagement(id);
            if (waterManagement == null)
            {
                return BadRequest("Water_Management not found");
            }

            return Ok(await _waterManagementService.UpdateWaterManagement(id, model.Capacity, model.Collection_Hour, model.Device_Id, model.Water_Management_Type_Id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Water_Management>> DeleteWaterManagement(int id)
        {
            var waterManagement = await _waterManagementService.GetWaterManagement(id);
            if (waterManagement == null)
            {
                return BadRequest("Water_Management not found");
            }
            return Ok(await _waterManagementService.DeleteWaterManagement(id));
        }

        [HttpPost]
        public async Task<ActionResult<Water_Management>> CreateWaterManagement([FromBody] Water_Management model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _waterManagementService.CreateWaterManagement(model.Capacity, (float)model.Collection_Hour, model.Device_Id, model.Water_Management_Type_Id);
        }

    }
}
