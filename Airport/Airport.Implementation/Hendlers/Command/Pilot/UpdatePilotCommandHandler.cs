using Abstractions.CQRS;
using Airport.Contract.Command.Pilot;
using Airport.Domain.Repositiories;
using System;
using System.Threading.Tasks;

namespace Airport.Implementation.Hendlers.Command
{
    public class UpdatePilotCommandHandler : ICommandHandler<UpdatePilotCommand>
    {
        private readonly IPilotRepository _pilotRepository;

        public UpdatePilotCommandHandler(IPilotRepository pilotRepository)
        {
            _pilotRepository = pilotRepository;
        }

        public async Task ExecuteAsync(UpdatePilotCommand command)
        {
            var pilot = await _pilotRepository.GetById(command.Id);

            if (pilot == null)
            {
                throw new Exception("Pilot with this Id does not exist");
            }

            pilot.FirstName = command.FirstName ?? pilot.FirstName;
            pilot.LastName = command.LastName ?? pilot.LastName;
            pilot.DateOfBirth = command.DateOfBirth;
            pilot.Experience = command.Experience;

            await _pilotRepository.Update(pilot);
        }
    }
}
