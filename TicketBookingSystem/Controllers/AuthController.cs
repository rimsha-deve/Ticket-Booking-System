using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketBookingSystem.Application.DTOs;
using TicketBookingSystem.Application.DTOs.Login;
using TicketBookingSystem.Application.Interfaces.Services.Auth;

namespace TicketBookingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("register")]
        public async Task<ActionResult<ApiResponse<AuthResponse>>> Register([FromBody] RegisterRequest request)
        {
             var response = await _authService.RegisterAsync(request);
             return response;
        }
           
        [HttpPost("login")]
        public async Task<ActionResult<ApiResponse<AuthResponse>>> Login([FromBody] LoginRequest request)
        {
            var response = await _authService.LoginAsync(request);
            return response; // implicit conversion to ActionResult<T>
        }
    }
}
