using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_01.Models;
using Project_01.Services;

namespace Project_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<string>> registerUser(UserDto request)
        {
            var user = await _userServices.RegisterUser(request);
            if (user is null) return BadRequest("User already exists");
            return Ok("Registeration Successfull");
        }
        [HttpPost("Login")]
        public async Task<ActionResult<string>> loginUser(LoginDto request)
        {
            var user = await _userServices.LoginUser(request);
            if (user is null) return BadRequest("Invalid username or password");
            return Ok(user);
        }
        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<IEnumerable<User>>> getAllUsers()
        {
            var users = await _userServices.GetUsers();
            if (users is null) return NotFound("Users not found");
            return Ok(users);
        }
        [HttpGet("GetUserById/{id}")]
        public async Task<ActionResult<User>> getUserById(int id)
        {
            var user = await _userServices.GetUserById(id);
            if (user is null) return NotFound("User not found");
            return Ok(user);
        }
    }
}
