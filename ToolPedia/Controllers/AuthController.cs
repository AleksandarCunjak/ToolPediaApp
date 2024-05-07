using System.Security.Claims;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ToolPedia.Application.Auth.Dto;
using ToolPedia.Application.Common.Interfaces;

namespace ToolPedia.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // [EnableCors("AllowFrontend")]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly IAuthenticationService _authenticationService;

        public AuthController(IJwtService jwtService, IAuthenticationService authenticationService)
        {
            _jwtService = jwtService;
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            var userId = await _authenticationService.RegisterUser(model.UserName, model.Password);
            if (userId == Guid.Empty)
            {
                return BadRequest("Registration failed");
            }

            var token = _jwtService.GenerateToken(userId, model.UserName);
            return Ok(new { Token = token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var userId = await _authenticationService.ValidateCredentials(
                model.UserName,
                model.Password
            );
            if (userId == Guid.Empty)
            {
                return Unauthorized("Invalid credentials");
            }

            var token = _jwtService.GenerateToken(userId, model.UserName);
            return Ok(new { Token = token });
        }
    }
}
