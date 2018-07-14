using Abstractions.CQRS;
using System;

namespace Airport.Contract.Command.Ticket
{
    public class DeleteTicketCommand : ICommand
    {
        public Guid TicketId { get; set; }
    }
}
