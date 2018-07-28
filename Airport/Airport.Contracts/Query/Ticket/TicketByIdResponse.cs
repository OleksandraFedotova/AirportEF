using Abstractions.CQRS;
using System;

namespace Airport.Contract.Query.Ticket
{
    public class TicketByIdResponse : IResponse
    {
        public Guid Id { get; set; }
        public double Price { get; set; }
        public int FlightNumber { get; set; }
    }
}
