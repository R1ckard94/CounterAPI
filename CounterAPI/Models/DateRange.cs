using System;
namespace CounterAPI.Models
{
    public class DateRange
    {
        public string[] Dates { get; set; }

        public double[] Avg { get; set; }

        public DateRange(string[] str, double[] avg) {
            Dates = str;
            Avg = avg;
        }
    }
}
