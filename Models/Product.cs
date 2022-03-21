using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbAPI.Models
{
    public class Product
    { 
        //sirve para que el id sea autoincremetental y no tiene que ser pasado en el metodo POST
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Category { get; set; }
    }
}

