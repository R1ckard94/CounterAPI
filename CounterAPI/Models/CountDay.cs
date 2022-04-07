using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace CounterAPI.Models
{
    public class CountDay
    {
        [BsonId]
        public string IdDate { get; set; }

        public int CurrAmount { get; set; }

        public int MaxAmount { get; set; }
    }
}
