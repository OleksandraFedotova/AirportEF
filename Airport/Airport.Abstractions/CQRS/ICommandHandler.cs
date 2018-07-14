using System.Threading.Tasks;

namespace Abstractions.CQRS
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task ExecuteAsync(TCommand command);
    }
}