using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace BritehouseMongo.Models
{
    public class RegistrationModel
    {
        [BsonId]
        public ObjectId id { get; set; }

        [BsonElement("Username")]
        public string Username { get; set; }

        [BsonElement("email")]
        public string email { get; set; }

        [BsonElement("password")]
        public string password { get; set; }
    }
}