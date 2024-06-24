using System.Text.Json.Serialization;

namespace todo_list_backend.DTOs;

public class SubTodoItemDto
{
    [JsonPropertyName("id")]
    public string Id { get; set; }
    [JsonRequired]
    [JsonPropertyName("description")]
    public string Description { get; set; }
    [JsonPropertyName("areThereAdditionalDetails")]
    public bool AreThereAdditionalDetails { get; set; }
    [JsonPropertyName("additionalDetails")]
    public string AdditionalDetails { get; set; }

    [JsonPropertyName("subTodoIsOverdue")]
    public bool SubTodoIsOverdue { get; set; }
    [JsonPropertyName("subTodoIsCompleted")]
    public bool SubTodoIsComplete { get; set; }
}
