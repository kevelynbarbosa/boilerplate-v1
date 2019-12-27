using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace v1.Domain.Users.Entities
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Email")]
        [Required]
        public string Email { get; set; }

        [BsonElement("Password")]
        [Required]
        public string Password { get; set; }

        public User(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }
    }
}
