using Airport.DataAccess;
using Airport.Domain.Entities;
using Airport.Domain.Repositiories;

namespace AirPort.DataAccess
{
    public class PilotRepository : BaseRepository<Pilot>, IPilotRepository
    {
        public PilotRepository(AirportDbContext dbContext) : base(dbContext)
        {

        }
        protected override void AddSeeds()
        {
         
        }
    }
}
