using Abstractions.CQRS;
using Airport.Contract.Command.Flight;
using Airport.Domain.Entities;
using Airport.Domain.Repositiories;
using AirPort.DataAccess;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Airport.Implementation.Hendlers.Command
{
    public class CreateFlightCommandHandler : ICommandHandler<CreateFlightCommand>
    {
        private readonly IFlightRepository _flightRepository;
        private readonly ITicketRepository _ticketRepository;

        public CreateFlightCommandHandler(IFlightRepository flightRepository, ITicketRepository ticketRepository)
        {
            _flightRepository = flightRepository;
            _ticketRepository = ticketRepository;
        }

        public async Task ExecuteAsync(CreateFlightCommand command)
        {
            if (await _flightRepository.GetById(command.Id) != null)
            {
                throw new Exception("Flight with same Id already exists");
            }

            var flight = new Flight
            {
                Id = command.Id,
                DeparturePoint=command.DeparturePoint,
                DepartureTime=command.DepartureTime,
                Destination=command.Destination,
                Number=command.Number,
                Tickets= _ticketRepository.GetAll().Where(y => command.TicketsId.Contains(y.Id)),
                TimeOfArrival=command.TimeOfArrival
        };

            await _flightRepository.Create(flight);
        }
    }
}
