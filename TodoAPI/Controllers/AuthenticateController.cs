using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TodoAPI.Domain.Dtos;
using TodoAPI.Domain.Services;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthenticateController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto model)
        {
            var response = await _authService.LoginAsync(model);

            if (response is null)
            {
                return Unauthorized();
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto model)
        {
            var result = await _authService.RegisterAsync(model);
            if (result is null)
            {
                return StatusCode(StatusCodes.Status409Conflict,
                    new { Status = "Error", Message = "User already exists!" });
            }

            var errors = result.Errors.Select(error => error.Description).ToList();

            return !result.Succeeded 
                ? StatusCode(StatusCodes.Status500InternalServerError, 
                    new
                    {
                        Status = "Error", 
                        Message = $"User creation failed! Please check user details and try again.", 
                        errors
                    }) 
                : Ok(new
                {
                    Status = "Success",
                    Message = "User created successfully!"
                });
        }

    }
}
