using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Lab8.Models
{
    public class Group : MongoBaseModel
    {
        [BsonElement("Name")]
        public string Name { get; set; }

        //[BsonRepresentation(BsonType.ObjectId)]
        public List<string> Students { get; set; }
    }
}
