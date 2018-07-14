using Abstractions.CQRS;

namespace Airport.Contract.Query.Ticket
{
    public class TicketByIdResponse : IResponse
    {
        public double Price { get; set; }
        public int FlightNumber { get; set; }
    }
}
