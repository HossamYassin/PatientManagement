using Microsoft.AspNetCore.Mvc;
using PatientManagement.Application.DTOs;
using PatientManagement.WebAPI.Models;
using PatientManagement.WebAPI.Services;

namespace PatientManagement.WebAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly FakeAuthService _authService;

        public AuthController(FakeAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var token = _authService.Authenticate(request.Email, request.Password);

            if (token == null)
                return Unauthorized((new ApiResponse<List<AppointmentDto>>(
                "fail", new List<string> { "Invalid credentials" })));

            return Ok(new { Token = token });
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
