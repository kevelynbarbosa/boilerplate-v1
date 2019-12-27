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

        [BsonElement("BirthDate")]
        [Required]
        public string BirthDate { get; set; }

        [BsonElement("CPF")]
        public string CPF { get; set; }

        [BsonElement("City")]
        public string City { get; set; }

        [BsonElement("CnhNumber")]
        [Required]
        public string CnhNumber { get; set; }

        [BsonElement("CnhCategory")]
        [Required]
        public string CnhCategory { get; set; }

        [BsonElement("CnhValidate")]
        public string CnhValidate { get; set; }

        public Driver(string name, string birthDate, string cpf, string city, string cnhNumber, string cnhCategory, string cnhValidate)
        {
            this.Name = name;
            this.BirthDate = birthDate;
            this.CPF = cpf;
            this.City = city;
            this.CnhNumber = cnhNumber;
            this.CnhCategory = cnhCategory;
            this.CnhValidate = cnhValidate;
        }

    }
}
