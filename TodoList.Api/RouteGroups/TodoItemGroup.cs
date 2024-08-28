using TodoList.Api.Endpoints;

namespace TodoList.Api.RouteGroups;

public static class TodoItemGroup
{
    public static void AddTodoItemEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/todoitems").WithTags("To Do List");

        group.MapGet("/", TodoItemEndpoints.GetTodoItems).WithName("GetTodoItems").WithOpenApi();

        group.MapGet("/complete", TodoItemEndpoints.GetTodoItemsComplete).WithName("GetTodoItemsComplete").WithOpenApi();

        group.MapGet("/{id}", TodoItemEndpoints.GetTodoItem).WithName("GetTodoItem").WithOpenApi();

        group.MapPost("/", TodoItemEndpoints.CreateTodoItem).WithName("CreateTodoItem").WithOpenApi();

        group.MapPut("/{id}", TodoItemEndpoints.UpdateTodoItem).WithName("UpdateTodoItem").WithOpenApi();

        group.MapDelete("/{id}", TodoItemEndpoints.DeleteTodoItem).WithName("DeleteTodoItem").WithOpenApi();
    }
}
