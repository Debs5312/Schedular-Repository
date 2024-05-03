using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models.API.ProcessAPI
{
    public class Process
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("project")]
        [JsonPropertyName("project")]
        public string? Project { get; set; }
        [BsonElement("processname")]
        [JsonPropertyName("processname")]
        public string? ProcessName { get; set; }
        [BsonElement("processdescription")]
        [JsonPropertyName("processdescription")]
        public string? ProcessDescription { get; set; }
        [BsonElement("author")]
        [JsonPropertyName("author")]
        public string? Author { get; set; }

        [BsonElement("activestatus")]
        [JsonPropertyName("activestatus")]
        public bool ActiveStatus { get; set; } = false;
    }
}