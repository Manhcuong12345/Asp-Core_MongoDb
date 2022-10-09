using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Project_Test.Models
{
    public class Country
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("address")]
        public string Address { get; set; }

    }
}
