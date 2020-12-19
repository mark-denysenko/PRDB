using Lab8.Models;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Lab8.Services
{
    public abstract class MongoServiceBase<T> where T : MongoBaseModel
    {
        public readonly IMongoCollection<T> items;

        public MongoServiceBase(string collectionName)
        {
            string connString = "mongodb://localhost:27017/TestUniversity";
            var connection = new MongoUrlBuilder(connString);
            var client = new MongoClient(connString);
            var database = client.GetDatabase(connection.DatabaseName);

            if (database.GetCollection<T>(collectionName) is null)
            {
                database.CreateCollection(collectionName);
            }

            items = database.GetCollection<T>(collectionName);
        }

        public List<T> Get() =>
            items.Find(book => true).ToList();

        public T Get(string id) =>
            items.Find(book => book.Id == id).FirstOrDefault();

        public T Create(T book)
        {
            items.InsertOne(book);
            return book;
        }

        public void Update(string id, T bookIn) =>
            items.ReplaceOne(book => book.Id == id, bookIn);

        public void Remove(T bookIn) =>
            items.DeleteOne(book => book.Id == bookIn.Id);

        public void Remove(string id) =>
            items.DeleteOne(book => book.Id == id);
    }
}
