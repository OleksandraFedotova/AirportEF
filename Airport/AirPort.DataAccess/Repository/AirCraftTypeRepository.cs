using Airport.DataAccess;
using Airport.Domain.Entities;
using Airport.Domain.Repositiories;

namespace AirPort.DataAccess
{
    public class AirCraftTypeRepository : BaseRepository<AirCraftType>, IAirCraftTypeRepository
    {
        public AirCraftTypeRepository(AirportDbContext dbContext) : base(dbContext)
        {

        }
        protected override void AddSeeds()
        {
            
        }
    }
}
