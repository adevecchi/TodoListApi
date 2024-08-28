namespace TodoList.Api.Models;

public class TodoItemModel
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    
    public bool IsComplete { get; set; }
}
