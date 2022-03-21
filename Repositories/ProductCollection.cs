using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDbAPI.Models;

namespace MongoDbAPI.Repositories   
{
    public class ProductCollection : IProductCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Product> Collection;

        public ProductCollection()
        {
            Collection = _repository.db.GetCollection<Product>("Products");
        }
        public async Task DeleteProduct(string id)
        {
            //igualamos que el id que se pasa por parametros sea el id de objectid de mongodb
            var filter = Builders<Product>.Filter.Eq(s => s.Id, new ObjectId(id));
                await Collection.DeleteOneAsync(filter);
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Product> GetProductById(string id)
        {
            return await Collection.FindAsync(
                new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }

        public async Task InsertProduct(Product product)
        {
            await Collection.InsertOneAsync(product);
        }

        public async Task UpdateProduct(Product product)
        {
            var filter = Builders<Product>
                .Filter
                .Eq(s => s.Id, product.Id);

            await Collection.ReplaceOneAsync(filter, product);
        }
    }
}