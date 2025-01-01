using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace mongoConnection2.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string? ProductName { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string? CategoryId { get; set; }

    }
}
