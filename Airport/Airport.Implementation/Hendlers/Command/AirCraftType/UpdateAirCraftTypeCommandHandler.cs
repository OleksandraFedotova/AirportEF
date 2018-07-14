using Abstractions.CQRS;
using Airport.Contract.Command.AirCraftType;
using Airport.Domain.Repositiories;
using System;
using System.Threading.Tasks;

namespace Airport.Implementation.Hendlers.Command
{
    public class UpdateAirCraftTypeCommandHandler : ICommandHandler<UpdateAirCraftTypeCommand>
    {
        private readonly IAirCraftTypeRepository _airCraftTypeRepository;

        public UpdateAirCraftTypeCommandHandler(IAirCraftTypeRepository airCraftTypeRepository)
        {
            _airCraftTypeRepository = airCraftTypeRepository;
        }

        public async Task ExecuteAsync(UpdateAirCraftTypeCommand command)
        {
            var airCraftType = await _airCraftTypeRepository.GetById(command.AirCraftTypeId);

            if (airCraftType == null)
            {
                throw new Exception("AirCraftType with this Id does not exist");
            }

            airCraftType.LoadCapacity = command.LoadCapacity;
            airCraftType.Model = command.Model ?? airCraftType.Model;
            airCraftType.Seats = command.Seats;

            await _airCraftTypeRepository.Update(airCraftType);
        }
    }
}
