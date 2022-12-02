using backend_practice.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend_practice.EntityFramework
{
    public class CarDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Boat> Boats { get; set; }

        public CarDbContext(DbContextOptions<CarDbContext> options) : base(options)
        {

        }
    }
}
