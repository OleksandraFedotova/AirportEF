using Abstractions.CQRS;
using Airport.Contract.Command.Pilot;
using Airport.Domain.Repositiories;
using System;
using System.Threading.Tasks;

namespace Airport.Implementation.Hendlers.Command.Pilot
{
    public class DeletePilotCommandHandler : ICommandHandler<DeletePilotCommand>
    {
        private readonly IPilotRepository _pilotRepository;

        public DeletePilotCommandHandler(IPilotRepository pilotRepository)
        {
            _pilotRepository = pilotRepository;
        }

        public async Task ExecuteAsync(DeletePilotCommand command)
        {
            var pilot = await _pilotRepository.GetById(command.PilotId);

            if (pilot == null)
            {
                throw new Exception("Pilot with this Id does not exist");
            }

            await _pilotRepository.Delete(pilot.Id);
        }
    }
}
