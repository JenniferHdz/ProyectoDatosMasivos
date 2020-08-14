using MongoDB.Driver;
using System;
using System.Configuration;

namespace ProyectoDatosMasivos.App_Start
{
    public class MongoDBContext
    {
        public IMongoDatabase database;

        public MongoDBContext()
        {
            var mongoClient = new MongoClient(ConfigurationManager.AppSettings["MongoDBHost"]);
            database = mongoClient.GetDatabase(ConfigurationManager.AppSettings["MongoDBName"]);
        }
    }
}