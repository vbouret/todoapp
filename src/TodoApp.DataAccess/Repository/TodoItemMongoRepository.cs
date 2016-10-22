using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.DataAccess.Model;

namespace TodoApp.DataAccess.Repository
{
    //mlab.com : mongo1todo
    //Database user: cbctodoapp_admin
    //Database password: admin
    //mongodb://<dbuser>:<dbpassword>@ds044989.mlab.com:44989/cbctodoapp
    //Database: cbctodoapp

    /// <summary>
    /// MongoDB repository implementation of CRUD operations
    /// </summary>
    public class TodoItemMongoRepository : BaseRepository, IRepository<TodoItem, string>, IDisposable
    {
        private readonly IMongoClient client;
        private readonly IMongoDatabase database;
        private readonly IMongoCollection<TodoItem> collection;

        public TodoItemMongoRepository(string dataSourceConnectionString, string databaseName) :
            base(dataSourceConnectionString, databaseName)
        {
            //BsonClassMap.RegisterClassMap<TodoItem>(); -- not needed, automatic
            client = new MongoClient(this.dataSourceConnectionString);
            database = client.GetDatabase(this.databaseName);
            collection = database.GetCollection<TodoItem>("todoItems");
        }

        public IEnumerable<TodoItem> GetAll()
        {
            var documents = collection.Find(new BsonDocument()).ToList();

            return documents;
        }

        public async Task<IEnumerable<TodoItem>> GetAllAsync()
        {
            var documents = await collection.Find(new BsonDocument()).ToListAsync();

            return documents;
        }

        public TodoItem GetItem(string id)
        {
            var filter = Builders<TodoItem>.Filter.Eq(t => t.Id, id);
            return collection.Find(filter).First();
        }

        public void Add(TodoItem item)
        {
            collection.InsertOne(item);
        }

        public void Delete(string id)
        {
            var filter = Builders<TodoItem>.Filter.Eq(t => t.Id, id);
            collection.DeleteOne(filter);
        }

        public void Update(TodoItem item)
        {
            var filter = Builders<TodoItem>.Filter.Eq(t => t.Id, item.Id);
            var update = Builders<TodoItem>.Update
                                .Set(t => t.Description, item.Description)
                                .Set(t => t.CompletionDate, item.CompletionDate)
                                .Set(t => t.DueDate, item.DueDate)
                                .Set(t => t.IsCompleted, item.IsCompleted);

            collection.UpdateOne(filter, update);
        }

        public void Dispose()
        {
            //No need to close connection to MongoDB
        }


    }
}
