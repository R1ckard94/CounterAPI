using System;
namespace CounterAPI.Models
{
    public class CountedPeopleDatabaseSettings : ICountedPeopleDatabaseSettings
    {
        public string CountedPeopleCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

    }
    public interface ICountedPeopleDatabaseSettings
    {
        string CountedPeopleCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}


/*
uppdatera databas  columner: id, date(dd-mm-yyyy-time), num
query för att hämta ut current antal, max antal
query för att hämta historik, avg och max. dag -> dagar -> veckor
query för att se när det är som mest folk under dagen.(alla rader på datum för datum och inom en timme när det är mest folk)
*/

