using Abstractions.CQRS;
using System;
using System.Collections.Generic;

namespace Airport.Contract.Query.Ticket
{
    public class TicketsResponse : IResponse
    {
        public IEnumerable<Ticket> Tickets { get; set; }

        public class Ticket
        {
            public Guid Id { get; set; }
            public double Price { get; set; }
            public int FlightNumber { get; set; }
        }
    }
}
