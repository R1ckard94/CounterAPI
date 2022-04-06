using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace CounterAPI.Models
{
    public class CountDay
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Date { get; set; }

        public int CurrAmount { get; set; }

        public int MaxAmount { get; set; }

        
    }
}
