using Abstractions.CQRS;
using Airport.Contract.Command.AirCraft;
using Airport.Domain.Repositiories;
using AirPort.DataAccess;
using System;
using System.Threading.Tasks;

namespace Airport.Implementation.Hendlers.Command
{
    public class UpdateAirCraftCommandHandler : ICommandHandler<UpdateAirCraftCommand>
    {
        private readonly IAirCraftRepository _airCraftRepository;

        public UpdateAirCraftCommandHandler(IAirCraftRepository airCraftRepository)
        {
            _airCraftRepository = airCraftRepository;
        }

        public async Task ExecuteAsync(UpdateAirCraftCommand command)
        {
            var airCraft = await _airCraftRepository.GetById(command.AirCraftId);

            if (airCraft == null)
            {
                throw new Exception("AirCraft with this Id does not exist");
            }


            airCraft.Name = command.Name ?? airCraft.Name;
            airCraft.TypeId = command.TypeId;
            airCraft.ReleaseDate = command.ReleaseDate;
            airCraft.TimeSpan = command.TimeSpan;

            await _airCraftRepository.Update(airCraft);
        }
    }
}
