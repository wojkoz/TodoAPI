using System.Collections.Generic;
using System.Threading.Tasks;
using Mapster;
using TodoAPI.Domain.Dtos;
using TodoAPI.Domain.Extensions;
using TodoAPI.Domain.Models;
using TodoAPI.Domain.Repositories;

namespace TodoAPI.Domain.Services.Impl
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<TodoDto> AddTodoAsync(CreateTodoDto createTodoDto, string userId)
        {
            await _todoRepository.InsertAsync(createTodoDto.ToTodo());
            await _todoRepository.Save();
            var todo = await _todoRepository.GetAsync(t =>
                (t.Title == createTodoDto.Title) &&
                (t.Description == createTodoDto.Description) &&
                (t.UserId == userId)
            );
        
            return todo?.Adapt<TodoDto>();
        }
        
        public async Task<IEnumerable<TodoDto>> GetUserTodoListAsync(string id)
        {
            var todos = await _todoRepository.GetAllAsync(t => t.UserId == id);
        
            return todos.Adapt<IEnumerable<TodoDto>>();
        }
        
        public async Task DeleteTodoAsync(long todoId, string userid)
        {
            await _todoRepository.DeleteAsync(todoId);
            await _todoRepository.Save();
        }
        
        public async Task<TodoDto> UpdateTodo(TodoDto dto)
        {
            _todoRepository.Update(dto.ToTodo());
            await _todoRepository.Save();
            var todo = await _todoRepository.GetAsync(t => t.TodoId == dto.TodoId);
            return todo?.Adapt<TodoDto>();
        }
    }
}
