using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TodoAPI.Domain.Models.Entities;
using TodoAPI.Domain.Repository;

namespace TodoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            _logger.LogInformation($"Entered {nameof(GetUsers)}");
            try
            {
                var users = await _unitOfWork.Users.GetAllAsync();
                return Ok(users);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error in {nameof(GetUsers)}");
                return StatusCode(500, "Server internal Error");
            }
        }
    }
}
