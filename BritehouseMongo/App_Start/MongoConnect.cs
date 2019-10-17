using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using System.Configuration;


namespace BritehouseMongo.App_Start
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
