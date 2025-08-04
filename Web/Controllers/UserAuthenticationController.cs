using Application.Services.UserManagement;
using Application.UserManagement.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserAuthenticationController : ControllerBase
    {
        private readonly UserAuthenticationService _userAuthenticationService;

        public UserAuthenticationController(UserAuthenticationService userAuthenticationService)
        {
            _userAuthenticationService = userAuthenticationService;
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _userAuthenticationService.LoginAsync(dto);

            if (!response.Success)
                return Unauthorized(response);

            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _userAuthenticationService.RegisterAsync(dto);

            if (!response.Success)
                return Conflict(response);

            return Ok(response);
        }
    }
}