using Abstractions.CQRS;
using Airport.Contract.Command.Ticket;
using Airport.Domain.Repositiories;
using System;
using System.Threading.Tasks;

namespace Airport.Implementation.Hendlers.Command.Pilot
{
    public class DeleteTicketCommandHandler : ICommandHandler<DeleteTicketCommand>
    {
        private readonly ITicketRepository _ticketRepository;

        public DeleteTicketCommandHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task ExecuteAsync(DeleteTicketCommand command)
        {
            var ticket = await _ticketRepository.GetById(command.TicketId);

            if (ticket == null)
            {
                throw new Exception("Ticket with this Id does not exist");
            }

            await _ticketRepository.Delete(ticket.Id);
        }
    }
}
