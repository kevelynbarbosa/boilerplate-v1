using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace v1.Domain.Drivers.Entities
{
    public class Driver
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        [Required]
        public string Name { get; set; }

        [BsonElement("Model")]
        [Required]
        public string Age { get; set; }

    }
}
