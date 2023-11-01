using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskBoard.Service.DTO;
using TaskBoard.Service.Interfaces;

namespace TaskBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [Authorize(Roles="Admin")]
        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await userService.GetAsync();

            return Ok(users);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("users")]
        public async Task<IActionResult> CreateUser(UserDTO model)
        {
            if (model == null)
                return BadRequest();

            var userModel = new UserDTO()
            {
                Login = model.Login,
                Password = model.Password,
                Codeword = model.Codeword
            };

            var checkUser = await userService.GetLoginUser(userModel);

            if (checkUser != null)
                return BadRequest(new { Message = "Login is not unique" });

            await userService.CreateAsync(userModel);

            return Ok(new { Message = "Added Success" });
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("users")]
        public async Task<IActionResult> UpdateRoleUser(UserDTO model)
        {
            if (model == null)
                return BadRequest();

            var userModel = new UserDTO()
            {
                Id = model.Id,
                Role = model.Role
            };

            var result = await userService.UpdateRoleAsync(userModel);

            if (result == true)
                return Ok(new { Message = "Update Role Success" });
            else
                return NotFound(new { Message = "Not Found" });
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("users/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await userService.DeleteAsync(id);

            if (result == true)
                return Ok(new { Message = "Delete Success" });
            else
                return NotFound(new { Message = "User not Found" });
        }
    }
}
