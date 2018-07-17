using Airport.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Airport.DataAccess
{
    public class AirportDbContext : DbContext
    {
        public AirportDbContext(DbContextOptions<AirportDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pilot> Pilots { get; set; }
        public DbSet<Stewardess> Stewardesses { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Departure> Departures { get; set; }
        public DbSet<AirCraft> AirCrafts { get; set; }
        public DbSet<AirCraftType> AirCraftTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }

    public class MockedDbContext
    {
        public static AirportDbContext Create()
        {
            DbContextOptions<AirportDbContext> options = new DbContextOptionsBuilder<AirportDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            var mockedContext = new AirportDbContext(options);

            return mockedContext;
        }
    }
}
