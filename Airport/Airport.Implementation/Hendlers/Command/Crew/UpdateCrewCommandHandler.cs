using Abstractions.CQRS;
using Airport.Contract.Command.Crew;
using Airport.Domain.Repositiories;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

            crew.Pilot = await _pilotRepository.GetById(command.PilotId);
            crew.Stewardesses = await _stewardessRepository.GetAll().Where(y => command.StewardressesId.Contains(y.Id))
                .ToListAsync();

            await _crewRepository.Update(crew);
        }
    }
}
