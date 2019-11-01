using MongoDB.Bson;
using MongoDB.Driver;
using System;

namespace MySmartApp.Models
{
    public class MongoDBContext
    {
        public static string ConnectionString { get; set; }
        public static string DatabaseName { get; set; }
        public static bool IsSSL { get; set; }

        private IMongoDatabase _database { get; }

        public MongoDBContext()
        {
            try
            {
                MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl("mongodb://localhost"));
                //if (IsSSL)
                //{
                //    settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
                //}
                var mongoClient = new MongoClient(settings);
                _database = mongoClient.GetDatabase("Devicedb");
            }
            catch (Exception ex)
            {
                throw new Exception("Can not access to db server.", ex);
            }
        }

        public IMongoCollection<BsonDocument> DeviceCollection
        {
            get
            {
                return _database.GetCollection<BsonDocument>("DeviceCollection");
            }
        }
    }
}