using Abstractions.CQRS;
using Airport.Contract.Command.Crew;
using Airport.Domain.Repositiories;
using AirPort.DataAccess;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Airport.Implementation.Hendlers.Command
{
    public class CreateCrewCommandHandler : ICommandHandler<CreateCrewCommand>
    {
        private readonly ICrewRepository _crewRepository;
        private readonly IPilotRepository _pilotRepository;
        private readonly IStewardessRepository _stewardessRepository;

        public CreateCrewCommandHandler(ICrewRepository crewRepository, IPilotRepository pilotRepository, IStewardessRepository stewardessRepository)
        {
            _crewRepository = crewRepository;
            _pilotRepository = pilotRepository;
            _stewardessRepository = stewardessRepository;
        }

        public async Task ExecuteAsync(CreateCrewCommand command)
        {
            if (await _crewRepository.GetById(command.Id) != null)
            {
                throw new Exception("Crew with same Id already exists");
            }

            var crew = new Domain.Entities.Crew
            {
                Id = command.Id,
                Pilot = _pilotRepository.GetById(command.PilotId).Result,
                Stewardesses = _stewardessRepository.GetAll().Where(y => command.StewardressesId.Contains(y.Id))
            };

            await _crewRepository.Create(crew);
        }
    }
}
