using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TodoAPI.Domain.Services;

namespace TodoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _userService;
        private readonly ILogger<UserController> _logger;

        public TodoController(ITodoService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }
    }
}
