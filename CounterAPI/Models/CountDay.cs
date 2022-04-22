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

        public string Date_and_time { get; set; }

        public bool PersonIn { get; set; }

        
    }
}
