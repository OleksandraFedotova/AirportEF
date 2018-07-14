using Abstractions.CQRS;
using System;

namespace Airport.Contract.Query.Departure
{
    public class DepartureByIdResponse : IResponse
    {
        public Guid Id { get; private set; }
        public int FlightNumber { get; set; }
        public DateTime DepartureDate { get; set; }
        public Guid CrewId { get; set; }
        public Guid AirCraftId { get; set; }
    }
}
