using Microsoft.EntityFrameworkCore;

using TodoList.Domain.Entities;

namespace TodoList.Data;

public class TodoItemsRepository : ITodoItemsRepository
{
    private readonly TodoListContext context;

    public TodoItemsRepository(TodoListContext context)
    {
        this.context = context;
    }

    public async Task<bool> CheckIfExists(int id)
    {
        var todoItem = await context.TodoItems.FindAsync(id);
        if (todoItem != null)
        {
            context.Entry(todoItem).State = EntityState.Detached;
            return true;
        }
        return false;
    }

    public async Task<List<TodoItem>> GetTodoItemsAsync()
    {
        return await context.TodoItems.ToListAsync();
    }

    public async Task<List<TodoItem>> GetTodoItemsCompleteAsync()
    {
        return await context.TodoItems.Where(t => t.IsComplete).ToListAsync();
    }

    public async Task<TodoItem?> GetTodoItemAsync(int id)
    {
        return await context.TodoItems.FindAsync(id);
    }

    public async Task<TodoItem> CreateTodoItemAsync(TodoItem item)
    {
        var addedItem = context.Add(item).Entity;
        await context.SaveChangesAsync();
        return addedItem;
    }

    public async Task<TodoItem> UpdateTodoItemAsync(TodoItem item)
    {
        var updatedItem = context.TodoItems.Update(item).Entity;
        await context.SaveChangesAsync();
        return updatedItem;
    }

    public async Task<TodoItem> DeleteTodoItemAsync(TodoItem item)
    {
        var deletedItem = context.TodoItems.Remove(item).Entity;
        await context.SaveChangesAsync();
        return deletedItem;
    }
}
