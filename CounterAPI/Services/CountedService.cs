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

            _countedDay = database.GetCollection<CountDay>(settings.CountedPeopleCollectionName);
        }

        public List<CountDay> Get() =>
            _countedDay.Find(counted => true).ToList();

        public CountDay Get(string date) =>
            _countedDay.Find(counted => counted.Date.Equals(date)).FirstOrDefault();

        public CountDay Create(CountDay count) 
        {
            _countedDay.InsertOne(count);
            return count;
        }

        public void Update(string date, CountDay countedIn) =>
            _countedDay.ReplaceOne(counted => counted.Date.Equals(date), countedIn);

        public void Remove(CountDay countedIn) =>
            _countedDay.DeleteOne(counted => counted.Id == countedIn.Id);

        public void Remove(string date) =>
            _countedDay.DeleteOne(counted => counted.Date.Equals(date));
    }
}