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
        public async Task<ActionResult<Water_Management>> UpdateWaterManagement(int id, float Capacity, float? Collection_Hour, int Device_Id, int Water_Management_Type_Id)
        {
            var user = await _waterManagementService.GetWaterManagement(id);
            if (user == null)
            {
                return BadRequest("Water_Management not found");
            }

            return Ok(await _waterManagementService.UpdateWaterManagement(id, Capacity, Collection_Hour, Device_Id, Water_Management_Type_Id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Water_Management>> DeleteWaterManagement(int id)
        {
            var user = await _waterManagementService.GetWaterManagement(id);
            if (user == null)
            {
                return BadRequest("Water_Management not found");
            }
            return Ok(await _waterManagementService.DeleteWaterManagement(id));
        }

        [HttpPost]
        public async Task<ActionResult<Water_Management>> CreateWaterManagement(float Capacity, float Collection_Hour, int Device_Id, int Water_Management_Type_Id)
        {
            return await _waterManagementService.CreateWaterManagement(Capacity, Collection_Hour, Device_Id, Water_Management_Type_Id);
        }
    }
}
