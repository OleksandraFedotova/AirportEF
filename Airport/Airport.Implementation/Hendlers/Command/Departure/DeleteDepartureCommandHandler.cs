using Abstractions.CQRS;
using Airport.Contract.Command.Departure;
using Airport.Domain.Repositiories;
using System;
using System.Threading.Tasks;

namespace Airport.Implementation.Hendlers.Command.Departure
{
    public class DeleteDepartureCommandHandler : ICommandHandler<DeleteDepartureCommand>
    {
        private readonly IDepartureRepository _departureRepository;

        public DeleteDepartureCommandHandler(IDepartureRepository departureRepository)
        {
            _departureRepository = departureRepository;
        }

        public async Task ExecuteAsync(DeleteDepartureCommand command)
        {
            var departure = await _departureRepository.GetById(command.DepartureId);

            if (departure == null)
            {
                throw new Exception("Departure with this Id does not exist");
            }

            await _departureRepository.Delete(departure.Id);
        }
    }
}
