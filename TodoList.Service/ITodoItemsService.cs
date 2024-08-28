using TodoList.Domain.Entities;

namespace TodoList.Service;

public interface ITodoItemsService
{
    Task<bool> CheckIfExists(int id);

    Task<List<TodoItem>> GetTodoItemsAsync();

    Task<List<TodoItem>> GetTodoItemsCompleteAsync();

    Task<TodoItem?> GetTodoItemAsync(int id);

    Task<TodoItem> CreateTodoItemAsync(TodoItem item);

    Task<TodoItem> UpdateTodoItemAsync(int id, TodoItem item);

    Task<TodoItem> DeleteTodoItemAsync(int id);
}
