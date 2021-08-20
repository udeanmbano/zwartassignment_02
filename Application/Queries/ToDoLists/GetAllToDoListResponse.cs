using System.Text.Json.Serialization;

namespace Application.Queries.GetAllToDoList.ToDoLists
{
    public class GetAllToDoListResponse
    {
        [JsonPropertyName("Id")]
          public int Id { get; set; }
        [JsonPropertyName("Name")]

        public string Name { get; set; }
        [JsonPropertyName("Description")]

        public string Description { get; set; }
        [JsonPropertyName("UserId")]

        public string UserId { get; set; }

       }
}