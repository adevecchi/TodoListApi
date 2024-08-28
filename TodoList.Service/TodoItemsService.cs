using TodoList.Domain.Entities;
using TodoList.Data;

namespace TodoList.Service;

public class TodoItemsService : ITodoItemsService
{
    private readonly ITodoItemsRepository repository;

    public TodoItemsService(ITodoItemsRepository repository)
    {
        this.repository = repository;
    }

    public async Task<bool> CheckIfExists(int id)
    {
        return await repository.CheckIfExists(id);
    }

    public async Task<List<TodoItem>> GetTodoItemsAsync()
    {
        return await repository.GetTodoItemsAsync();
    }

    public async Task<List<TodoItem>> GetTodoItemsCompleteAsync()
    {
        return await repository.GetTodoItemsCompleteAsync();
    }

    public async Task<TodoItem?> GetTodoItemAsync(int id)
    {
        return await repository.GetTodoItemAsync(id);
    }

    public async Task<TodoItem> CreateTodoItemAsync(TodoItem item)
    {
        return await repository.CreateTodoItemAsync(item);
    }

    public async Task<TodoItem> UpdateTodoItemAsync(int id, TodoItem item)
    {
        if (id != item.Id)
        {
            throw new KeyNotFoundException("BadRequest");
        }

        if (! await CheckIfExists(id))
        {
            throw new KeyNotFoundException("NotFound");
        }

        return await repository.UpdateTodoItemAsync(item);
    }

    public async Task<TodoItem> DeleteTodoItemAsync(int id)
    {
        var todoItem = await repository.GetTodoItemAsync(id);

        if (todoItem is null)
        {
            throw new KeyNotFoundException();
        }

        return await repository.DeleteTodoItemAsync(todoItem);
    }
}
