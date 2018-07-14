using Abstractions.CQRS;
using System;

namespace Airport.Contract.Query.Ticket
{
    public class TicketByIdQuery : IQuery<TicketByIdResponse>
    {
        public Guid TicketId { get; set; }
    }
}
