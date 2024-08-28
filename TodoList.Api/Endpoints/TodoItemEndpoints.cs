using Microsoft.AspNetCore.Mvc;

using AutoMapper;
using FluentValidation;

using TodoList.Service;
using TodoList.Domain.Entities;
using TodoList.Api.Models;

namespace TodoList.Api.Endpoints;

public static class TodoItemEndpoints
{
    public static async Task<IResult> GetTodoItems(ITodoItemsService service, IMapper mapper)
    {
        var todoItems = await service.GetTodoItemsAsync();
        var todoItemsModel = mapper.Map<IEnumerable<TodoItemModel>>(todoItems);
        return Results.Ok(todoItemsModel);
    }

    public static async Task<IResult> GetTodoItemsComplete(ITodoItemsService service, IMapper mapper)
    {
        var todoItems = await service.GetTodoItemsCompleteAsync();
        var todoItemsModel = mapper.Map<IEnumerable<TodoItemModel>>(todoItems);
        return Results.Ok(todoItemsModel);
    }

    public static async Task<IResult> GetTodoItem(int id, ITodoItemsService service, IMapper mapper)
    {
        var todoItem = await service.GetTodoItemAsync(id);
        var todoItemModel = mapper.Map<TodoItemModel>(todoItem);
        return todoItem is null ? Results.NotFound() : Results.Ok(todoItemModel);
    }

    public static async Task<IResult> CreateTodoItem(TodoItemModel itemModel, ITodoItemsService service, IValidator<TodoItemModel> validator, IMapper mapper)
    {
        var validationResult = validator.Validate(itemModel);

        if (validationResult.IsValid) 
        {
            var todoItemToAdd = mapper.Map<TodoItem>(itemModel);
            var createdItem = await service.CreateTodoItemAsync(todoItemToAdd);
            return Results.CreatedAtRoute("GetTodoItem", new { id = createdItem.Id }, createdItem);
        }
        
        return Results.ValidationProblem(validationResult.ToDictionary());
    }

    public static async Task<IResult> UpdateTodoItem(int id, TodoItemModel itemModel, ITodoItemsService service, IValidator<TodoItemModel> validator, IMapper mapper)
    {
        var validationResult = validator.Validate(itemModel);

        if (validationResult.IsValid)
        {
            try
            {
                var todoItemToUpdate = mapper.Map<TodoItem>(itemModel);
                await service.UpdateTodoItemAsync(id, todoItemToUpdate);
                return Results.NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                switch (ex.Message)
                {
                    case "BadRequest": return Results.BadRequest();
                    default: return Results.NotFound();
                }
            }
        }
        
        return Results.ValidationProblem(validationResult.ToDictionary());
    }

    public static async Task<IResult> DeleteTodoItem(int id, ITodoItemsService service)
    {
        try
        {
            await service.DeleteTodoItemAsync(id);
            return Results.NoContent();
        }
        catch (KeyNotFoundException)
        {
            return Results.NotFound();
        }
    }
}
