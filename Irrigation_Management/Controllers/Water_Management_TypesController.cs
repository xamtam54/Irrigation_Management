using Irrigation_Management.Models;
using Irrigation_Management.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Irrigation_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Water_Management_TypesController : ControllerBase
    {
        private readonly IWaterManagementTypesService _waterManagementTypesService;

        public Water_Management_TypesController(IWaterManagementTypesService waterManagementTypesService)
        {
            _waterManagementTypesService = waterManagementTypesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Water_Management_Types>>> GetAll()
        {
            return Ok(await _waterManagementTypesService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Water_Management_Types>> GetWaterManagementType(int id)
        {
            var user = await _waterManagementTypesService.GetWaterManagementType(id);
            if (user == null)
            {
                return BadRequest("Water_Management_Types not found");
            }

            return Ok(user);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Water_Management_Types>> UpdateWaterManagementType(int id, string Type_Name, string Description, string Material)
        {
            var user = await _waterManagementTypesService.GetWaterManagementType(id);
            if (user == null)
            {
                return BadRequest("Water_Management_Types not found");
            }

            return Ok(await _waterManagementTypesService.UpdateWaterManagementType(id, Type_Name, Description, Material));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Water_Management_Types>> DeleteWaterManagementType(int id)
        {
            var user = await _waterManagementTypesService.GetWaterManagementType(id);
            if (user == null)
            {
                return BadRequest("Water_Management_Types not found");
            }
            return Ok(await _waterManagementTypesService.DeleteWaterManagementType(id));
        }

        [HttpPost]
        public async Task<ActionResult<Water_Management_Types>> CreateWaterManagementType(string Type_Name, string Description, string Material)
        {
            return await _waterManagementTypesService.CreateWaterManagementType(Type_Name, Description, Material);
        }
    }
}
