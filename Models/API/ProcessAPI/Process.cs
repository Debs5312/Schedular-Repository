using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models.API.ProcessAPI
{
    public class Process
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? ProcessName { get; set; }
        public string? ProcessDescription { get; set; }
        public string? Author { get; set; }
        public DateTime Created { get; set; }
        public bool ActiveStatus { get; set; } = false;
    }
}