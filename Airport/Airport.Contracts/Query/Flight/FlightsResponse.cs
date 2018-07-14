using Abstractions.CQRS;
using System;
using System.Collections.Generic;

namespace Airport.Contract.Query.Flight
{
    public class FlightsResponse : IResponse
    {
        public IEnumerable<Flight> Flights { get; set; }

        public class Flight
        {
            public Guid Id { get; private set; }
            public int Number { get; set; }
            public string DeparturePoint { get; set; }
            public DateTime DepartureTime { get; set; }
            public string Destination { get; set; }
            public DateTime TimeOfArrival { get; set; }
            public Guid TicketId { get; set; }
        }
    }
}
