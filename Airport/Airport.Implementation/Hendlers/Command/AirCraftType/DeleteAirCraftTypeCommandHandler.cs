using Abstractions.CQRS;
using Airport.Contract.Command.AirCraftType;
using Airport.Domain.Repositiories;
using System;
using System.Threading.Tasks;

namespace Airport.Implementation.Hendlers.Command.AirCraftType
{
    public class DeleteAirCraftTypeCommandHandler : ICommandHandler<DeleteAirCraftTypeCommand>
    {
        private readonly IAirCraftTypeRepository _airCraftTypeRepository;

        public DeleteAirCraftTypeCommandHandler(IAirCraftTypeRepository airCraftTypeRepository)
        {
            _airCraftTypeRepository = airCraftTypeRepository;
        }

        public async Task ExecuteAsync(DeleteAirCraftTypeCommand command)
        {
            var airCraftType = await _airCraftTypeRepository.GetById(command.AirCraftTypeId);

            if (airCraftType == null)
            {
                throw new Exception("AirCraftType with this Id does not exist");
            }

            await _airCraftTypeRepository.Delete(airCraftType.Id);
        }
    }
}
