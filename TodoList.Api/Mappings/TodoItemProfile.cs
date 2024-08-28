using AutoMapper;

using TodoList.Domain.Entities;
using TodoList.Api.Models;

namespace TodoList.Api.Mappings;

public class TodoItemProfile : Profile
{
    public TodoItemProfile()
    {
        CreateMap<TodoItem, TodoItemModel>();
        CreateMap<TodoItemModel, TodoItem>();
    }
}
