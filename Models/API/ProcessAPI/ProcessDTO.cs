using System.Text.Json.Serialization;

namespace Models.API.ProcessAPI
{
    public class ProcessDTO
    {
        public string? Id { get; set; }
        [JsonPropertyName("project")]
        public string? Project { get; set; }
        [JsonPropertyName("processname")]
        public string? ProcessName { get; set; }
        [JsonPropertyName("processdescription")]
        public string? ProcessDescription { get; set; }
        [JsonPropertyName("author")]
        public string? Author { get; set; }
    }
}