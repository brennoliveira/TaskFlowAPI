using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.Services;
using TaskFlow.Application.DTOs;
using TaskFlow.Application.Interfaces;
using TaskFlow.CrossCutting.Responses;
using Microsoft.OpenApi.Any;

namespace TaskFlow.Api.Cnotrollers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        [HttpPost("register")]
        [ProducesResponseType(typeof(ApiSuccessResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Register(RegisterUserDTO dto)
        {
            await _userService.RegisterAsync(dto);
            return Created("", new ApiSuccessResponse("User registered successfully"));
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(ApiSuccessResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login(LoginUserDTO dto)
        {
            var token = await _userService.LoginAsync(dto);
            return Ok(new ApiSuccessResponse<object>(new { Token = token }));
        }
    }
}
