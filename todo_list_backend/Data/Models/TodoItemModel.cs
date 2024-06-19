namespace todo_list_backend.Data.Models;

public class TodoItemModel
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public bool AreThereAdditionalDetails { get; set; }
    public string AdditionalDetails { get; set; }
}