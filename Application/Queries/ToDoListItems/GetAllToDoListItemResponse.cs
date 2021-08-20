using System.Text.Json.Serialization;

namespace Application.Queries.GetAllToDoList.ToDoListItem
{
    public class GetAllToDoListItemResponse
    {
        [JsonPropertyName("ToDoListItemId")]
        public int ToDoListItemId { get; set; }
        [JsonPropertyName("ToDoItem")]

        public string ToDoItem { get; set; }
        [JsonPropertyName("ItemDoneStatus")]

        public bool ItemDoneStatus { get; set; }
        [JsonPropertyName("ToDoListId")]

        public int ToDoListId { get; set; }


    }
}