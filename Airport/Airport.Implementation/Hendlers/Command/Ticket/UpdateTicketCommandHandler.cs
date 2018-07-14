using Abstractions.CQRS;
using Airport.Contract.Command.Ticket;
using Airport.Domain.Repositiories;
using System;
using System.Threading.Tasks;

namespace Airport.Implementation.Hendlers.Command
{
    public class UpdateTicketCommandHandler : ICommandHandler<UpdateTicketCommand>
    {
        private readonly ITicketRepository _ticketRepository;

        public UpdateTicketCommandHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task ExecuteAsync(UpdateTicketCommand command)
        {
            var ticket = await _ticketRepository.GetById(command.Id);

            if (ticket == null)
            {
                throw new Exception("Ticket with this Id does not exist");
            }

            ticket.Price = command.Price;
            ticket.FlightNumber = command.FlightNumber;

            await _ticketRepository.Update(ticket);
        }
    }
}
