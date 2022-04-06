using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CounterAPI.Models
{
    public class CountDay
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Date")]
        public string Date { get; set; }

        public int CurrAmount { get; set; }

        public int MaxAmount { get; set; }
    }
}
