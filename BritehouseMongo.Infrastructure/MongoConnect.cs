using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using System.Configuration;

//used instead of a context class
namespace BritehouseMongo.Infrastructure
{
    public class MongoConnect
    {
        public IMongoDatabase database;

        public MongoConnect()
        {
            var mongoClient = new MongoClient(ConfigurationManager.AppSettings["MongoDBHost"]);
            database = mongoClient.GetDatabase(ConfigurationManager.AppSettings["MongoDBName"]);
        }
    }

}
