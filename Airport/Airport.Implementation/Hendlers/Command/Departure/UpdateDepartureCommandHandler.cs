using Abstractions.CQRS;
using Airport.Contract.Command.Departure;
using Airport.Domain.Repositiories;
using System;
using System.Threading.Tasks;

namespace Airport.Implementation.Hendlers.Command
{
    public class UpdateDepartureCommandHandler : ICommandHandler<UpdateDepartureCommand>
    {
        private readonly IDepartureRepository _departureRepository;

        public UpdateDepartureCommandHandler(IDepartureRepository departureRepository)
        {
            _departureRepository = departureRepository;
        }

        public async Task ExecuteAsync(UpdateDepartureCommand command)
        {
            var departure = await _departureRepository.GetById(command.DepartureId);

            if (departure == null)
            {
                throw new Exception("Departure with this Id does not exist");
            }

            departure.AirCraftId = command.AirCraftId;
            departure.CrewId = command.CrewId;
            departure.DepartureDate = command.DepartureDate;
            departure.FlightNumber = command.FlightNumber;

            await _departureRepository.Update(departure);
        }
    }
}
