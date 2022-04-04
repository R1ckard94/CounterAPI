using Microsoft.EntityFrameworkCore;

namespace CounterAPI.Models
{
    public class CountDayContext : DbContext
    {
        public CountDayContext(DbContextOptions<CountDayContext> options)
            : base(options)
        {
        }

        public DbSet<CountDay> CounterAPIDays { get; set; }
    }
}