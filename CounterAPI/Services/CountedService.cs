using CounterAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace CounterAPI.Services
{
    public class CountedService
    {
        private readonly IMongoCollection<CountDay> _countedDay;

        public CountedService(ICountedPeopleDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _countedDay = database.GetCollection<CountDay>(settings.CountedCollectionName);
        }

        public List<CountDay> Get() =>
            _countedDay.Find(counted => true).ToList();

        public CountDay Get(string id) =>
            _countedDay.Find<CountDay>(counted => counted.Id == id).FirstOrDefault();

        public CountDay Create(CountDay count)
        {
            _countedDay.InsertOne(count);
            return count;
        }

        public void Update(string id, CountDay countedIn) =>
            _countedDay.ReplaceOne(counted => counted.Id == id, countedIn);

        public void Remove(CountDay countedIn) =>
            _countedDay.DeleteOne(counted => counted.Id == countedIn.Id);

        public void Remove(string id) =>
            _countedDay.DeleteOne(counted => counted.Id == id);
    }
}