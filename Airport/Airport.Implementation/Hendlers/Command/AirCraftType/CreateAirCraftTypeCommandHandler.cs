using Abstractions.CQRS;
using Airport.Contract.Command.AirCraftType;
using Airport.Domain.Repositiories;
using AirPort.DataAccess;
using AutoMapper;
using System;
using System.Threading.Tasks;

namespace Airport.Implementation.Hendlers.Command
{
    public class CreateAirCraftTypeCommandHandler : ICommandHandler<CreateAirCraftTypeCommand>
    {
        private readonly IAirCraftTypeRepository _airCraftTypeRepository;
        private readonly IMapper _mapper;

        public CreateAirCraftTypeCommandHandler(IAirCraftTypeRepository airCraftTypeRepository, IMapper mapper)
        {
            _airCraftTypeRepository = airCraftTypeRepository;
            _mapper = mapper;
        }

        public async Task ExecuteAsync(CreateAirCraftTypeCommand command)
        {
            if (await _airCraftTypeRepository.GetById(command.Id) != null)
            {
                throw new Exception("AirCraftType with same Id already exists");
            }

            var airCraftType = _mapper.Map<Airport.Domain.Entities.AirCraftType>(command);

            await _airCraftTypeRepository.Create(airCraftType);
        }
    }
}
