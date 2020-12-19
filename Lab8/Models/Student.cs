using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Lab8.Models
{
    public class Student : Human
    {
        public DateTime JoinDate { get; set; }

        //[BsonRepresentation(BsonType.ObjectId)]
        public string GroupId { get; set; }

        //[BsonIgnore]
        public List<MarkModel> MarkList { get; set; }
    }
}
