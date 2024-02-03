using CarBookingApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CarBookingApp.Data.Data
{
    public class CarBookAppContext : DbContext
    {
        // DbSet is a collection of entities that can be queried from the database
        public DbSet<Car> Cars { get; set; }
        // Constructor that takes options as a parameter and passes it to the base class constructor (DbContext)
        public CarBookAppContext(DbContextOptions<CarBookAppContext> options) : base(options)
        {
        }
        // Used to configure the DbContext options such as the database provider, connection string, etc.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasData(
            new Car
            {
                CarId = Guid.NewGuid(),
                Year = 2020,
                Name = "Toyota Corolla"
            },
            new Car
            {
                CarId = Guid.NewGuid(),
                Year = 2018,
                Name = "Honda Civic"
            },
            new Car
            {
                CarId = Guid.NewGuid(),
                Year = 2017,
                Name = "Nissan Sentra"
            },
            new Car
            {
                CarId = Guid.NewGuid(),
                Year = 2016,
                Name = "Ford Focus"
            },
            new Car
            {
                CarId = Guid.NewGuid(),
                Year = 2015,
                Name = "Chevrolet Cruze"
            }                                                                         
          );
        }
    }
}
