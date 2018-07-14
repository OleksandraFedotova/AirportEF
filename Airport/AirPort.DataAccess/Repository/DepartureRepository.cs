using Airport.DataAccess;
using Airport.Domain.Entities;
using Airport.Domain.Repositiories;

namespace AirPort.DataAccess
{
    public class DepartureRepository : BaseRepository<Departure>, IDepartureRepository
    {
        public DepartureRepository(AirportDbContext dbContext) : base(dbContext)
        {
                
        }

        protected override void AddSeeds()
        {
           
        }
    }
}
