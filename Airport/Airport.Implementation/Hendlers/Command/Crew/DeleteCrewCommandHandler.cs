using Abstractions.CQRS;
using Airport.Contract.Command.Crew;
using Airport.Domain.Repositiories;
using System;
using System.Threading.Tasks;

namespace Airport.Implementation.Hendlers.Command.Crew
{
    public class DeleteCrewCommandHandler : ICommandHandler<DeleteCrewCommand>
    {
        private readonly ICrewRepository _crewRepository;

        public DeleteCrewCommandHandler(ICrewRepository crewRepository)
        {
            _crewRepository = crewRepository;
        }

        public async Task ExecuteAsync(DeleteCrewCommand command)
        {
            var crew = await _crewRepository.GetById(command.CrewId);

            if (crew == null)
            {
                throw new Exception("Crew with this Id does not exist");
            }

            await _crewRepository.Delete(crew.Id);
        }
    }
}
