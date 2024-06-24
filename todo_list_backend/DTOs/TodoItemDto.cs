using System.Text.Json.Serialization;

namespace todo_list_backend.DTOs;

public class TodoItemDto
{
    [JsonPropertyName("id")]
    public string Id { get; set; }
    [JsonRequired]
    [JsonPropertyName("description")]
    public string Description { get; set; }
    [JsonRequired]
    [JsonPropertyName("deadline")]
    public string Deadline { get; set; }
    [JsonPropertyName("areThereAdditionalDetails")]
    public bool AreThereAdditionalDetails { get; set; }
    [JsonPropertyName("additionalDetails")]
    public string AdditionalDetails { get; set; }
    [JsonPropertyName("todoIsOverdue")]
    public bool TodoIsOverdue { get; set; }
    [JsonPropertyName("todoIsCompleted")]

    public bool TodoIsCompleted { get; set; }
    [JsonPropertyName("hasLessThanTwoSubTodos")]
    public bool HasLessThanTwoSubTodos { get; set; }
    [JsonPropertyName("subTodos")]
    public ICollection<SubTodoItemDto>? SubTodoItems { get; set; }
}
