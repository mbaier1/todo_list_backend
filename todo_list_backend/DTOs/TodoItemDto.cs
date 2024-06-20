using System.Text.Json.Serialization;

namespace todo_list_backend.DTOs;

public class TodoItemDto
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }
    [JsonPropertyName("deadline")]
    public string Deadline { get; set; }
    [JsonPropertyName("areThereAdditionalDetails")]
    public bool AreThereAdditionalDetails { get; set; }
    [JsonPropertyName("additionalDetails")]
    public string AdditionalDetails { get; set; }
    [JsonPropertyName("todoIsOverdue")]
    public bool TodoIsOverdue { get; set; }
}
