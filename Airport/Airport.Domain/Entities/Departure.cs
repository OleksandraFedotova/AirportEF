using System;
using Airport.Domain.Repositiories;

namespace Airport.Domain.Entities
{
    public class Departure : IEntity
    {
        public Guid Id { get; set; }
        public int FlightNumber { get; set; }
        public DateTime DepartureDate { get; set; }
        public Guid CrewId { get; set; }
        public Guid AirCraftId { get; set; }
    }
}
