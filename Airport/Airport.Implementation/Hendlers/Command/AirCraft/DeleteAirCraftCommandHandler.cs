using Abstractions.CQRS;
using Airport.Contract.Command.AirCraft;
using Airport.Domain.Repositiories;
using AirPort.DataAccess;
using System;
using System.Threading.Tasks;

namespace Airport.Implementation.Hendlers.Command.AirCraft
{
    public class DeleteAirCraftCommandHandler : ICommandHandler<DeleteAirCraftCommand>
    {
        private readonly IAirCraftRepository _airCraftRepository;

        public DeleteAirCraftCommandHandler(IAirCraftRepository airCraftRepository)
        {
            _airCraftRepository = airCraftRepository;
        }

        public async Task ExecuteAsync(DeleteAirCraftCommand command)
        {
            var airCraft = await _airCraftRepository.GetById(command.AirCraftId);

            if (airCraft == null)
            {
                throw new Exception("AirCraft with this Id does not exist");
            }

            await _airCraftRepository.Delete(airCraft.Id);
        }
    }
}
