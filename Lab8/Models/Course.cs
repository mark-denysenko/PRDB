using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab8.Models
{
    public class Course : MongoBaseModel
    {
        public string Name { get; set; }

        public float Credits { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        //[BsonRepresentation(BsonType.ObjectId)]
        public string TeacherId { get; set; }

        //[BsonRepresentation(BsonType.ObjectId)]
        public List<string> Groups { get; set; }
    }
}
