using System.Threading.Tasks;
using Abstractions.CQRS;

namespace Abstractions.Bus
{
    public interface ICommandBus
    {
        Task ExecuteAsync<TCommand>(TCommand command) where TCommand : ICommand;
    }
}