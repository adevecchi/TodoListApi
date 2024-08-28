using System.ComponentModel.DataAnnotations;

namespace TodoList.Domain.Entities;

public class TodoItem
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public bool IsComplete { get; set; }
}
