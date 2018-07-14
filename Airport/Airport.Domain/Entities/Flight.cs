using Airport.Domain.Repositiories;
using System;
using System.Collections.Generic;

namespace Airport.Domain.Entities
{
    public class Flight : IEntity
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string DeparturePoint { get; set; }
        public DateTime DepartureTime { get; set; }
        public string Destination { get; set; }
        public DateTime TimeOfArrival { get; set; }
        public IEnumerable<Ticket> Tickets{ get; set; }
    }
}
