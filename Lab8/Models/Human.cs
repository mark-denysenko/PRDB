using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Lab8.Models
{
    public class Human : MongoBaseModel
    {
        [BsonElement("Name")]
        public string Name { get; set; }

        public string Phone { get; set; }
    }
}
