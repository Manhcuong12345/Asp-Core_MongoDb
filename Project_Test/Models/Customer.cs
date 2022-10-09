using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Project_Test.Models
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("firstName")]
        public string FirstName { get; set; } 

        [BsonElement("lastName")]
        public string LastName { get; set; }

        [BsonElement("contact")]
        public string Contact { get; set; }
        [BsonElement("country")]
        public string CountryId { get; set; }

        [BsonElement("countries")]
        public Country Country { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }
    }
}
