using System;
using System.Threading.Tasks;
using System.Timers;
using System.Linq;
using Airport.DataAccess;
using Airport.Domain.Entities;
using Airport.Domain.Repositiories;
using Microsoft.EntityFrameworkCore;

namespace AirPort.DataAccess
{
    public class FlightRepository : BaseRepository<Flight>, IFlightRepository
    {
        public FlightRepository(AirportDbContext dbContext) : base(dbContext)
        {

        }

        public Task<Flight> GetByIdWithDelay(Guid id, double delay)
        {
            var tcs = new TaskCompletionSource<Flight>();

            var timer = new Timer(delay);

            timer.Elapsed += (a, b) =>
            {
                try
                {
                    var flight = _dbContext.Flights.AsNoTracking().FirstOrDefault(f => f.Id == id);

                    tcs.SetResult(flight);
                }
                catch (Exception e)
                {
                    tcs.SetException(e);
                }
            };

            return tcs.Task;
        }

        protected override void AddSeeds()
        {

        }
    }
}
