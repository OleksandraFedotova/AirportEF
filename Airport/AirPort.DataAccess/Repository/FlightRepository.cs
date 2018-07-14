using Airport.DataAccess;
using Airport.Domain.Entities;
using Airport.Domain.Repositiories;

namespace AirPort.DataAccess
{
    public class FlightRepository : BaseRepository<Flight>, IFlightRepository
    {
        public FlightRepository(AirportDbContext dbContext) : base(dbContext)
        {

        }

        protected override void AddSeeds()
        {

        }
    }
}
