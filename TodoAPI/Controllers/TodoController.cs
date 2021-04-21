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
        private readonly ILogger<TodoController> _logger;

        public TodoController(ITodoService userService, ILogger<TodoController> logger)
        {
            _userService = userService;
            _logger = logger;
        }
    }
}
