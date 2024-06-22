
namespace todo_list_backend.Data.Models;

public class SubTodoItem
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public string AdditionalDetails { get; set; }
    public bool SubTodoIsOverdue { get; set; }
    public bool SubTodoIsComplete { get; set; }
    public Guid TodoId { get; set; }
}
