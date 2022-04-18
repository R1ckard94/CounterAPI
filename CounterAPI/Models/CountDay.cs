using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace CounterAPI.Models
{
    public class CountDay
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdDate { get; set; }

        public string date_and_time { get; set; }

        public bool personIn { get; set; }

        
    }
}
