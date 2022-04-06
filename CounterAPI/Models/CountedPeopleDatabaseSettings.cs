using System;
namespace CounterAPI.Models
{
    public class CountedPeopleDatabaseSettings : ICountedPeopleDatabaseSettings
    {
        public string CountedCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

    }
    public interface ICountedPeopleDatabaseSettings
    {
        string CountedCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
