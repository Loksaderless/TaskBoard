using Microsoft.AspNetCore.Mvc;
using TaskBoard.Service.Interfaces;
using TaskBoard.Service.DTO;
using TaskBoard.Service.Helpers;

namespace TaskBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateUser(UserDTO model)
        {
            if (model == null)
                return BadRequest();

            var userModel = new UserDTO()
            {
                Login = model.Login,
                Password = model.Password,
            };

            var checkUser = await accountService.GetLoginUser(userModel);

            if (checkUser == null)
                return NotFound(new { Message = "User not Found" });

            if (checkUser.Password != HashHelpers.HashPasswordCode(userModel.Password))
                return NotFound(new { Message = "Incorrect password" });

            var token = await accountService.Authorization(checkUser);

            return Ok(new
            {
                Token = token,
                Message = "Login Success!" 
            });

        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(UserDTO model)
        {
            if (model == null)
                return BadRequest();

            var userModel = new UserDTO()
            {
                Login = model.Login,
                Password = model.Password,
                Codeword = model.Codeword
            };

            var checkUser = await accountService.GetLoginUser(userModel);
        
            if (checkUser != null)
                return BadRequest(new { Message = "Login is not unique" });
                       
            await accountService.Register(userModel);
              
            return Ok(new { Messsage = "Registration Successful" });
        }

        [HttpPost("restore")]
        public async Task<IActionResult> RestorePassword(UserDTO model)
        {
            if (model == null)
                return BadRequest();

            var userModel = new UserDTO()
            {
                Login = model.Login,
                Codeword = model.Codeword
            };

            var checkUser = await accountService.GetLoginUser(userModel);

            if (checkUser == null)
                return NotFound(new { Message = "User not Found" });

            if (checkUser.Codeword != HashHelpers.HashPasswordCode(userModel.Codeword))
                return NotFound(new { Message = "Incorrect codeword" });

            var passwordNew = await accountService.UpdatePassword(userModel);

            return Ok(new { Message = $"New password: {passwordNew}" });
        }
    }
}
