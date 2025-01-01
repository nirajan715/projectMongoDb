using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace mongoConnection2.Models
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Gmail { get; set; }
    }
}
