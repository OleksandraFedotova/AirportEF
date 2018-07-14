using Airport.DataAccess;
using Airport.Domain.Entities;
using Airport.Domain.Repositiories;

namespace AirPort.DataAccess
{
    public class AirCraftRepository : BaseRepository<AirCraft>, IAirCraftRepository
    {

        public AirCraftRepository(AirportDbContext dbContext):base (dbContext)
        {

        }
        protected override void AddSeeds()
        {

        }
    }
}
