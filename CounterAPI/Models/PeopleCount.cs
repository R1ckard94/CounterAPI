using System;
namespace CounterAPI.Models
{
    public class PeopleCount
    {
        public int Current { get; set; }

        public int MaxAmount { get; set; }

        public int[] Arr { get; set; }

        public PeopleCount(int curr, int max) {
            Current = curr;
            MaxAmount = max;
            Arr = null;
        }

        public PeopleCount(int curr, int max, int[] array)
        {
            Current = curr;
            MaxAmount = max;
            Arr = array;
        }
    }
}
