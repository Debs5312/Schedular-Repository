using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models.API.UserAPI
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public List<string> Role { get; set; } =  new List<string> {"member"};
        public DateTime? CreatedModifiedTime { get; set; } = DateTime.Now;
        public bool ActiveStatus { get; set; } = false;
    }
}