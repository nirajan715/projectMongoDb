using Microsoft.Extensions.Options;
using mongoConnection2.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace mongoConnection2.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMongoCollection<Customer> _customerCollection;
        private readonly IOptions<DatabaseSettings> _dbSettings;

        public CustomerService(IOptions<DatabaseSettings> dbSettings)
        {
            _dbSettings = dbSettings;
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _customerCollection = mongoDatabase.GetCollection<Customer>
                (dbSettings.Value.CustomerCollectionName);
        }


        //public async Task<IEnumerable<Customer>> GetAllAsync()
        //{
        //    //Define the pipeline for the aggregation query
        //    var pipeline = new BsonDocument[]
        //    {
        //        new BsonDocument("$lookup", new BsonDocument
        //        {
        //            { "from", "CategoryCollection" },
        //            { "localField", "CategoryId" },
        //            { "foreignField", "_id" },
        //            { "as", "customer_category" }
        //        }),
        //        new BsonDocument("$unwind", "$customer_category"),
        //        new BsonDocument("$project", new BsonDocument
        //        {
        //            { "_id", 1 },
        //            { "CategoryId", 1 },
        //            { "CustomerName", 1 },
        //            { "CategoryName", "$customer_category.CategoryName" }
        //        })
        //    };

        //    var results = await _customerCollection.Aggregate<Customer>(pipeline).ToListAsync();
        //    return results;
        //}

        public async Task<IEnumerable<Customer>> GetAllAsync() =>
            await _customerCollection.Find(_ => true).ToListAsync();
        public async Task<Customer> GetById(string id) =>
            await _customerCollection.Find(a => a.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Customer Customer) =>
            await _customerCollection.InsertOneAsync(Customer);

        public async Task UpdateAsync(string id,Customer Customer) =>
            await _customerCollection
            .ReplaceOneAsync(a => a.Id == Customer.Id, Customer);

        public async Task DeleteAsync(string id) =>
            await _customerCollection .DeleteOneAsync(a => a.Id == id);
    }
}
