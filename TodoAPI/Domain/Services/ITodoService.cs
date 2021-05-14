using System.Collections.Generic;
using System.Threading.Tasks;
using TodoAPI.Domain.Dtos;
using TodoAPI.Domain.Models;

namespace TodoAPI.Domain.Services
{
    public interface ITodoService
    {
        Task<TodoDto> AddTodoAsync(CreateTodoDto createTodoDto, string userId);
        Task<IEnumerable<TodoDto>> GetUserTodoListAsync(string id);
        Task DeleteTodoAsync(long todoId, string userId);
        Task<TodoDto> UpdateTodo(TodoDto dto);
    }
}
