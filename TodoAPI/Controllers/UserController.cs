using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TodoAPI.Domain.Dtos;
using TodoAPI.Domain.Models;
using TodoAPI.Domain.Services;

namespace TodoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            _logger.LogInformation($"Entered {nameof(GetUsers)}");
            try
            {
                var users = await _userService.GetAllUsersAsync();
                return Ok(users.Adapt<IEnumerable<UserDto>>());
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error in {nameof(GetUsers)}");
                return StatusCode(500, "Server internal Error");
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserDto>> GetUserById(long id)
        {
            _logger.LogInformation($"Entered {nameof(GetUserById)}");
            try
            {
                var user = await _userService.GetUserAsync(id);
                if (user is null)
                {
                    return NoContent();
                }
                return Ok(user);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error in {nameof(GetUserById)}");
                return StatusCode(500, "Server internal Error");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserDto>> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            _logger.LogInformation($"Entered {nameof(CreateUser)}");
            try
            {
                var user = await _userService.CreateUserAsync(createUserDto);
                return StatusCode(201, new {user});
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error in {nameof(CreateUser)}");
                return StatusCode(500, "Server internal Error");
            }
        }
    }
}
