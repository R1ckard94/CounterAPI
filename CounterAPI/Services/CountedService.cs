using CounterAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System;

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

        public CountDay Get(string idDate) =>
            _countedDay.Find(counted => counted.IdDate == idDate).FirstOrDefault();

        public CountDay Create(CountDay count)
        {

            _countedDay.InsertOne(count);
            return count;
   
        }

        public void Update(string idDate, CountDay countedIn) =>
            _countedDay.ReplaceOne(counted => counted.IdDate == idDate, countedIn);

        public void Remove(CountDay countedIn) =>
            _countedDay.DeleteOne(counted => counted.IdDate == countedIn.IdDate);

        public void Remove(string idDate) =>
            _countedDay.DeleteOne(counted => counted.IdDate == idDate);
    }
}