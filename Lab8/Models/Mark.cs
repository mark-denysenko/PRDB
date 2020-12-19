using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab8.Models
{
    public class MarkModel : MongoBaseModel
    {
        public int Mark { get; set; }

        //[BsonRepresentation(BsonType.ObjectId)]
        public string CourseId { get; set; }
    }
}
