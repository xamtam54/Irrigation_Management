﻿using Irrigation_Management.Models;
using Irrigation_Management.Repository;
using Irrigation_Management.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Irrigation_Management.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<ActionResult<Users>> UpdateUser(int id, string UserName, string Names, string Surnames, string Password, string Email, int Is_Active, int User_Type_Id, string? City)
        {
            var user = await _usersService.GetUser(id);
            if (user == null)
            {
                return BadRequest("User not found");
            }

            return Ok(await _usersService.UpdateUser(id, UserName, Names, Surnames, Password, Email, Is_Active, User_Type_Id, City));
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
        public async Task<ActionResult<Users>> CreateUser(string UserName, string Names, string Surnames, string Password, string Email, int User_Type_Id, string? City)
        {
            var userTypes = await _user_TypesService.GetUserType(User_Type_Id);
            if (userTypes == null)
            {
                return BadRequest("User Type not found");
            }
            return await _usersService.CreateUser(UserName, Names, Surnames, Password, Email, User_Type_Id, City);
        }


        [HttpGet("allocations/{userId}")]
        public async Task<ActionResult<List<Allocation_Systems>>> GetAllocationsByUserId(int userId)
        {
            var allocations = await _usersService.GetAllocationsByUserId(userId);
            if (allocations == null || allocations.Count == 0)
            {
                return BadRequest("No allocations found for the user");
            }
            return Ok(allocations);
        }

        //-----------------------------------------------------------------
        [HttpPut("app/{id}")]
        public async Task<ActionResult<Users>> UpdateUser(int id, [FromBody] Users model)
        {
            var user = await _usersService.GetUser(id);
            if (user == null)
            {
                return BadRequest("User not found");
            }

            return Ok(await _usersService.UpdateUser(id, model.UserName, model.Names, model.Surnames, model.Password, model.Email, model.Is_Active, model.User_Type_Id, model.City));
        }

        [HttpPost("app")]
        public async Task<ActionResult<Users>> CreateUser([FromBody] Users model)
        {
            var userTypes = await _user_TypesService.GetUserType(model.User_Type_Id);
            if (userTypes == null)
            {
                return BadRequest("User Type not found");
            }
            return await _usersService.CreateUser(model.UserName, model.Names, model.Surnames, model.Password, model.Email, model.User_Type_Id, model.City);
        }

        [HttpGet("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await _usersService.AuthenticateAsync(username, password);

            if (user == null)
                return Unauthorized(new { message = "Username or password is incorrect" });

            return Ok(user);
        }
    }
}
