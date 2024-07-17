using FEProject.Users;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FEProject.Controllers
{
    [ApiController]
    [Route("api/employee")]
    public class UserController : ControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [HttpPost("createUser")]
        public async Task<IActionResult> CreateUserAsync(CreateUserDto input)
        {
            var result = await _userAppService.CreateUserAsync(input);
            return Ok("user created successfully");
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginDto input)
        {
            var result = await _userAppService.LoginAsync(input);
            return Ok("user logined"); // Replace with actual JWT token if using JWT
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePasswordAsync(ChangePasswordDto input)
        {
            await _userAppService.ChangePasswordAsync(input);
            return Ok("Password Changed Successfully.");
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPasswordAsync(string email)
        {
            await _userAppService.ForgotPasswordAsync(email);
            return Ok("email with token has been sent");
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPasswordAsync(ResetPwDto input)
        {
            await _userAppService.ResetPasswordAsync(input);
            return NoContent();
        }
    }
}
