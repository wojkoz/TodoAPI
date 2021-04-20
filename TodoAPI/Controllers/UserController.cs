using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TodoAPI.Domain.Models.Entities;
using TodoAPI.Domain.Repository;
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
    }
}
