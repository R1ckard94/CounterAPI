using System;
namespace CounterAPI.Models
{
    public class PeopleCount
    {
        public int Current { get; set; }

        public int MaxAmount { get; set; }

        public PeopleCount(int curr, int max) {
            Current = curr;
            MaxAmount = max;
        }
    }
}
