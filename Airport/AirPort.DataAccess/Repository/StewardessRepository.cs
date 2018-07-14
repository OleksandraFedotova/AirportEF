using Airport.DataAccess;
using Airport.Domain.Entities;
using Airport.Domain.Repositiories;
using System;

namespace AirPort.DataAccess
{
    public class StewardessRepository : BaseRepository<Stewardess>, IStewardessRepository
    {
        public StewardessRepository(AirportDbContext dbContext) : base(dbContext)
        {

        }
        protected override void AddSeeds()
        {
           
        }
    }
}
