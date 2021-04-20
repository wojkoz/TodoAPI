﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TodoAPI.Domain.Dtos;
using TodoAPI.Domain.Models.Entities;

namespace TodoAPI.Domain.Services
{
    public interface ITodoService
    {
        Task<TodoDto> AddTodoAsync(long userId, CreateTodoDto createTodoDto);
        Task<IEnumerable<TodoDto>> GetUserTodoListAsync(long id);
        Task DeleteTodoAsync(long todoId);
        Task<TodoDto> UpdateTodo(TodoDto dto);
    }
}