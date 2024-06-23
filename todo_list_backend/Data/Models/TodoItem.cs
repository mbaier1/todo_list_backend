namespace todo_list_backend.Data.Models;

public class TodoItem
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public string Deadline { get; set; }
    public string AdditionalDetails { get; set; }
    public bool TodoIsOverdue { get; set; }
    public bool TodoIsCompleted { get; set; }
    public ICollection<SubTodoItem> SubTodoItems { get; set; }
}