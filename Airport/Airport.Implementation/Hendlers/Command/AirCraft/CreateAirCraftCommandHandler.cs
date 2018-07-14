using Abstractions.CQRS;
using Airport.Contract.Command.AirCraft;
using Airport.Domain.Repositiories;
using AirPort.DataAccess;
using AutoMapper;
using System;
using System.Threading.Tasks;

namespace Airport.Implementation.Hendlers.Command
{
    public class CreateAirCraftCommandHandler : ICommandHandler<CreateAirCraftCommand>
    {
        private readonly IAirCraftRepository _airCraftRepository;
        private readonly IMapper _mapper;

        public CreateAirCraftCommandHandler(IAirCraftRepository airCraftRepository, IMapper mapper)
        {
            _airCraftRepository = airCraftRepository;
            _mapper = mapper;
        }

        public async Task ExecuteAsync(CreateAirCraftCommand command)
        {
            if (await _airCraftRepository.GetById(command.Id) != null)
            {
                throw new Exception("AirCraft  with same Id already exists");
            }

            var airCraft = _mapper.Map<Airport.Domain.Entities.AirCraft>(command);

            await _airCraftRepository.Create(airCraft);
        }
    }
}
