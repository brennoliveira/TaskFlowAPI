using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.Services;
using TaskFlow.Application.DTOs;
using TaskFlow.Application.Interfaces;

namespace TaskFlow.Api.Cnotrollers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDTO dto)
        {
            await _userService.RegisterAsync(dto);
            return Ok(new { Message = "User registered successfully." });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDTO dto)
        {
            var token = await _userService.LoginAsync(dto);
            return Ok(new { Token = token });
        }
    }
}
