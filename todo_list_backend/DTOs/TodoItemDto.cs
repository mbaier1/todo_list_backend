namespace todo_list_backend.DTOs;

public class TodoItemDto
{
    public string Description { get; set; }
    public string DueDate { get; set; }
    public bool AreThereAdditionalDetails { get; set; }
    public string AdditionalDetails { get; set; }
}
