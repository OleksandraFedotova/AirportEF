using Airport.DataAccess;
using Airport.Domain.Entities;
using Airport.Domain.Repositiories;
using System;
using System.Collections.Generic;

namespace AirPort.DataAccess
{
    public class TicketRepository : BaseRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(AirportDbContext dbContext) : base(dbContext)
        {
                
        }

        protected override void AddSeeds()
        {

        }
    }
}
