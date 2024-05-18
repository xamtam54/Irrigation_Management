using Irrigation_Management.Models;
using Irrigation_Management.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Irrigation_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class User_TypesController : ControllerBase
    {
        private readonly IUser_TypesService _user_TypesService;

        public User_TypesController(IUser_TypesService user_TypesService)
        {
            _user_TypesService = user_TypesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<User_Types>>> GetAll()
        {
            return Ok(await _user_TypesService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User_Types>> GetUserType(int id)
        {
            var user = await _user_TypesService.GetUserType(id);
            if (user == null)
            {
                return BadRequest("User_Types not found");
            }

            return Ok(user);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<User_Types>> UpdateUserType(int id, [FromBody] User_Types model)
        {
            var user = await _user_TypesService.GetUserType(id);
            if (user == null)
            {
                return BadRequest("User_Types not found");
            }

            return Ok(await _user_TypesService.UpdateUserType(id, model.User_Type_Name));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User_Types>> DeleteUserType(int id)
        {
            var user = await _user_TypesService.GetUserType(id);
            if (user == null)
            {
                return BadRequest("User_Types not found");
            }
            return Ok(await _user_TypesService.DeleteUserType(id));
        }

        [HttpPost]
        public async Task<ActionResult<User_Types>> CreateUserType([FromBody] User_Types model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _user_TypesService.CreateUserType(model.User_Type_Name);
        }
        
    }
}
