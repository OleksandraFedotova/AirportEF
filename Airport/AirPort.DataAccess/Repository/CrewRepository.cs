using Airport.DataAccess;
using Airport.Domain.Entities;
using Airport.Domain.Repositiories;

namespace AirPort.DataAccess
{
    public class CrewRepository : BaseRepository<Crew>, ICrewRepository
    {
        public CrewRepository(AirportDbContext dbContext) : base(dbContext)
        {

        }
        protected override void AddSeeds()
        {
        }
    }
}
