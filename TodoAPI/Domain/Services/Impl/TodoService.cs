using System.Collections.Generic;
using System.Threading.Tasks;
using TodoAPI.Domain.Dtos;
using TodoAPI.Domain.Models.Entities;
using TodoAPI.Domain.Repository;

namespace TodoAPI.Domain.Services.Impl
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<TodoDto> AddTodoAsync(long userId, CreateTodoDto createTodoDto)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<TodoDto>> GetUserTodoListAsync(long id)
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteTodoAsync(long todoId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<TodoDto> UpdateTodo(TodoDto dto)
        {
            throw new System.NotImplementedException();
        }
    }
}
