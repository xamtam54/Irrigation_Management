using Irrigation_Management.Models;
using Irrigation_Management.Repository;
using Irrigation_Management.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Irrigation_Management.Controllers
{
    [Route("/")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUsersService _usersService;
        private readonly IUser_TypesService _user_TypesService;

        

        public UsersController(IUsersService userService, IUser_TypesService user_TypesService)
        {
            _usersService = userService;
            _user_TypesService = user_TypesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Users>>> GetAll()
        {
            return Ok(await _usersService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUser(int id)
        {
            var user = await _usersService.GetUser(id);
            if (user == null)
            {
                return BadRequest("User not found");
            }

            return Ok(user);
        }
        

        [HttpPut("{id}")]
        public async Task<ActionResult<Users>> UpdateUser(int id, string UserName, string Names, string Surnames, string Password, string Email, int Is_Active, int User_Type_Id)
        {
            var user = await _usersService.GetUser(id);
            if (user == null)
            {
                return BadRequest("User not found");
            }

            return Ok(await _usersService.UpdateUser(id, UserName, Names, Surnames, Password, Email, Is_Active, User_Type_Id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Users>> DeleteUser(int id) 
        {
            var user = await _usersService.GetUser(id);
            if (user == null)
            {
                return BadRequest("User not found");
            }
            return Ok(await _usersService.DeleteUser(id));
        }

        [HttpPost]
        public async Task<ActionResult<Users>> CreateUser(string UserName, string Names, string Surnames, string Password, string Email, int User_Type_Id)
        {
            var userTypes = await _user_TypesService.GetUserType(User_Type_Id);
            if (userTypes == null)
            {
                return BadRequest("User Type not found");
            }
            return await _usersService.CreateUser(UserName, Names, Surnames, Password, Email, User_Type_Id);
        }




    }
}
