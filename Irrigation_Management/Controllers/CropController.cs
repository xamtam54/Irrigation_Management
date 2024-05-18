using Irrigation_Management.Models;
using Irrigation_Management.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Irrigation_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CropController : ControllerBase
    {
        private readonly ICropStatusService _cropStatusService;

        public CropController(ICropStatusService cropStatusService)
        {
            _cropStatusService = cropStatusService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Crop_Status>>> GetAll()
        {
            return Ok(await _cropStatusService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Crop_Status>> GetCrop_Status(int id)
        {
            var user = await _cropStatusService.GetCropStatus(id);
            if (user == null)
            {
                return BadRequest("Crop_Status not found");
            }

            return Ok(user);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Crop_Status>> UpdateCrop_Status(int id, [FromBody] Crop_Status model)
        {
            var cropStatus = await _cropStatusService.GetCropStatus(id);
            if (cropStatus == null)
            {
                return BadRequest("Crop_Status not found");
            }

            return Ok(await _cropStatusService.UpdateCropStatus(id, model.Crop_Status_Name, model.Production_Percentage));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Crop_Status>> DeleteCrop_Status(int id)
        {
            var cropStatus = await _cropStatusService.GetCropStatus(id);
            if (cropStatus == null)
            {
                return BadRequest("Crop_Status not found");
            }
            return Ok(await _cropStatusService.DeleteCropStatus(id));
        }

        [HttpPost]
        public async Task<ActionResult<Crop_Status>> CreateCrop_Status([FromBody] Crop_Status model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _cropStatusService.CreateCropStatus(model.Crop_Status_Name, model.Production_Percentage);
        }
    }
}
