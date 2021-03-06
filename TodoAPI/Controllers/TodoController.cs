using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TodoAPI.Domain.Dtos;
using TodoAPI.Domain.Models;
using TodoAPI.Domain.Services;

namespace TodoAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/user/{userId}/todo")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _userService;
        private readonly ILogger<TodoController> _logger;

        public TodoController(ITodoService userService, ILogger<TodoController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<TodoDto>>> GetTodosByUserId(string userId)
        {
            
                _logger.LogInformation($"Entered {nameof(GetTodosByUserId)}");
                try
                {
                    var todos = await _userService.GetUserTodoListAsync(userId);
                    return Ok(todos);
                }
                catch (Exception e)
                {
                    _logger.LogError(e, $"Error in {nameof(GetTodosByUserId)}");
                    return StatusCode(500, "Server internal Error");
                }
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<TodoDto>>> CreateTodo(string userId, [FromBody] CreateTodoDto createTodoDto)
        {
        
            _logger.LogInformation($"Entered {nameof(CreateTodo)}");
            try
            {
                var todos = await _userService.AddTodoAsync(createTodoDto, userId);
                return Ok(todos);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error in {nameof(CreateTodo)}");
                return StatusCode(500, "Server internal Error");
            }
        }
        
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<TodoDto>>> UpdateTodo(string userId, [FromBody] TodoDto todoDto)
        {
        
            _logger.LogInformation($"Entered {nameof(UpdateTodo)}");
            try
            {
                var todos = await _userService.UpdateTodo(todoDto);
                return Ok(todos);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error in {nameof(UpdateTodo)}");
                return StatusCode(500, "Server internal Error");
            }
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<TodoDto>>> DeleteTodo(string userId, long id)
        {

            _logger.LogInformation($"Entered {nameof(UpdateTodo)}");
            try
            {
                await _userService.DeleteTodoAsync(id, userId);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error in {nameof(UpdateTodo)}");
                return StatusCode(500, "Server internal Error");
            }
        }
    }
}
