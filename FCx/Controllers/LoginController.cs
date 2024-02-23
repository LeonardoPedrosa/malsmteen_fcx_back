using FCx.Domain.Entities;
using FCx.Services;
using Microsoft.AspNetCore.Mvc;

namespace FCx.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserService _userService;

        public LoginController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            var user = await _userService.GetUserByUsernameAsync(loginRequest.Username);
            if (user == null)
            {
                return NotFound("User not found");
            }

            if (user.Password != loginRequest.Password)
            {
                return Unauthorized("Invalid password");
            }

            return Ok(new { Message = "Login successful", UserId = user.Id });
        }

        [HttpPost("resetpassword")]
        public async Task<IActionResult> ResetPasswordAsync(ResetPasswordRequest resetPasswordRequest)
        {
            var user = await _userService.GetUserByDataAsync(resetPasswordRequest);

            if(user == null)
            {
                return NotFound("User not found");
            }

            return Ok();
        }

        [HttpPost("updatepassword")]
        public async Task<IActionResult> UpdatePasswordAsync(LoginRequest loginRequest)
        {
            var user = await _userService.GetUserByUsernameAsync(loginRequest.Username);
            if (user == null)
            {
                return NotFound("User not found");
            }

            await _userService.UpdatePasswordAsync(loginRequest);

            return Ok();
        }

    }
}
