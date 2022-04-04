using System;
namespace CounterAPI.Models
{
    public class CountDay
    {
        public long Id { get; set; }
        public string Date { get; set; }
        public int CurrAmount { get; set; }
        public int MaxAmount { get; set; }
    }
}
