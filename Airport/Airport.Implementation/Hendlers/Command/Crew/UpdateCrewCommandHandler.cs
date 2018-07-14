using Abstractions.CQRS;
using Airport.Contract.Command.Crew;
using Airport.Domain.Repositiories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Airport.Implementation.Hendlers.Command
{
    public class UpdateCrewCommandHandler : ICommandHandler<UpdateCrewCommand>
    {
        private readonly ICrewRepository _crewRepository;
        private readonly IPilotRepository _pilotRepository;
        private readonly IStewardessRepository _stewardessRepository;

        public UpdateCrewCommandHandler(ICrewRepository crewRepository,IPilotRepository pilotRepository, IStewardessRepository stewardessRepository)
        {
            _crewRepository = crewRepository;
            _pilotRepository = pilotRepository;
            _stewardessRepository = stewardessRepository;
        }

        public async Task ExecuteAsync(UpdateCrewCommand command)
        {
            var crew = await _crewRepository.GetById(command.CrewId);

            if (crew == null)
            {
                throw new Exception("Crew with this Id does not exist");
            }

            crew.Pilot = _pilotRepository.GetById(command.PilotId).Result;
            crew.Stewardesses = _stewardessRepository.GetAll().Where(y => command.StewardressesId.Contains(y.Id));

            await _crewRepository.Update(crew);
        }
    }
}
