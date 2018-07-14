using Abstractions.CQRS;
using System;
using System.Collections.Generic;

namespace Airport.Contract.Query.Departure
{
    public class DeparturesResponse : IResponse
    {
        public IEnumerable<Departure> Departures { get; set; }

        public class Departure
        {
            public Guid Id { get; private set; }
            public int FlightNumber { get; set; }
            public DateTime DepartureDate { get; set; }
            public Guid CrewId { get; set; }
            public Guid AirCraftId { get; set; }
        }
    }
}
