using Abstractions.CQRS;
using Airport.Contract.Command.Pilot;
using Airport.Domain.Repositiories;
using AirPort.DataAccess;
using AutoMapper;
using System;
using System.Threading.Tasks;

namespace Airport.Implementation.Hendlers.Command
{
    public class CreatePilotCommandHandler : ICommandHandler<CreatePilotCommand>
    {
        private readonly IPilotRepository _pilotRepository;
        private readonly IMapper _mapper;

        public CreatePilotCommandHandler(IPilotRepository pilotRepository, IMapper mapper)
        {
            _pilotRepository = pilotRepository;
            _mapper = mapper;
        }

        public async Task ExecuteAsync(CreatePilotCommand command)
        {
            if (await _pilotRepository.GetById(command.Id) != null)
            {
                throw new Exception("Pilot with same Id already exists");
            }

            var pilot = _mapper.Map<Airport.Domain.Entities.Pilot>(command);

            await _pilotRepository.Create(pilot);
        }
    }
}
