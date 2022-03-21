using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace MongoDbAPI.Repositories
{
    public class MongoDBRepository
    {
        public MongoClient client;
        public IMongoDatabase db;
        public MongoDBRepository()
        {
            //ruta o ip de la base de datos
            client = new MongoClient("mongodb://127.0.0.1:27017");
            //
            db = client.GetDatabase("Inventory");
        }
    }
}