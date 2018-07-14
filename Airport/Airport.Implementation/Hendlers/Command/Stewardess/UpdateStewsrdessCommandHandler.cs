using Abstractions.CQRS;
using Airport.Contract.Command.Stewardress;
using Airport.Domain.Repositiories;
using System;
using System.Threading.Tasks;

namespace Airport.Implementation.Hendlers.Command
{
    public class UpdateStewsrdessCommandHandler : ICommandHandler<UpdateStewardressCommand>
    {
        private readonly IStewardessRepository _stewardessRepository;

        public UpdateStewsrdessCommandHandler(IStewardessRepository stewardessRepository)
        {
            _stewardessRepository = stewardessRepository;
        }

        public async Task ExecuteAsync(UpdateStewardressCommand command)
        {
            var stewardess = await _stewardessRepository.GetById(command.Id);

            if (stewardess == null)
            {
                throw new Exception("Stewardess with this Id does not exist");
            }

            stewardess.FirstName = command.FirstName ?? stewardess.FirstName;
            stewardess.LastName = command.LastName ?? stewardess.LastName;
            stewardess.DateOfBirth = command.DateOfBirth;

            await _stewardessRepository.Update(stewardess);
        }
    }
}
