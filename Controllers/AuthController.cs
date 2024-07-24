using Microsoft.AspNetCore.Mvc;
using StudentsServices.Dtos;
using StudentsServices.Services;

namespace StudentsServices.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var result = await _authService.Register(registerDto);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var tokenDto = await _authService.Authenticate(loginDto);
            if (tokenDto == null)
            {
                return Unauthorized("Invalid credentials.");
            }
            return Ok(tokenDto);
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken(TokenDto tokenDto)
        {
            var newTokenDto = await _authService.RefreshToken(tokenDto);
            if (newTokenDto == null)
            {
                return Unauthorized("Invalid refresh token.");
            }
            return Ok(newTokenDto);
        }

        [HttpPut("update/{email}")]
        public async Task<IActionResult> UpdateUser(string email, UpdateUser updateUser)
        {
            var result = await _authService.UpdateUser(email, updateUser);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return Ok("User updated successfully.");
        }
    }
}