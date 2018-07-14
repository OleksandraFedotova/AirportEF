using Abstractions.CQRS;
using Airport.Contract.Command.Stewardress;
using Airport.Domain.Repositiories;
using System;
using System.Threading.Tasks;

namespace Airport.Implementation.Hendlers.Command.Pilot
{
    public class DeleteStewardressCommandHandler : ICommandHandler<DeleteStewardessCommand>
    {
        private readonly IStewardessRepository _stewardessRepository;

        public DeleteStewardressCommandHandler(IStewardessRepository stewardessRepository)
        {
            _stewardessRepository = stewardessRepository;
        }


        public async Task ExecuteAsync(DeleteStewardessCommand command)
        {
            var stewardess = await _stewardessRepository.GetById(command.StewardessId);

            if (stewardess == null)
            {
                throw new Exception("Stewardess with this Id does not exist");
            }

            await _stewardessRepository.Delete(stewardess.Id);
        }
    }
}
