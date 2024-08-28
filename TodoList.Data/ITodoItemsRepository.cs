using TodoList.Domain.Entities;

namespace TodoList.Data;

public interface ITodoItemsRepository
{
    Task<bool> CheckIfExists(int id);

    Task<List<TodoItem>> GetTodoItemsAsync();

    Task<List<TodoItem>> GetTodoItemsCompleteAsync();

    Task<TodoItem?> GetTodoItemAsync(int id);

    Task<TodoItem> CreateTodoItemAsync(TodoItem item);

    Task<TodoItem> UpdateTodoItemAsync(TodoItem item);

    Task<TodoItem> DeleteTodoItemAsync(TodoItem item);
}
