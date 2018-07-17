using System;
using System.Threading.Tasks;
using Abstractions.Bus;
using Abstractions.CQRS;
using Autofac;

namespace Infrastructure.Bus
{
    public class CommandBus : ICommandBus
    {
        private readonly ILifetimeScope _container;

        public CommandBus(ILifetimeScope container)
        {
            _container = container;
        }

        public async Task ExecuteAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            try
            {
                var handler = _container.ResolveOptional<ICommandHandler<TCommand>>();
                if (handler == null)
                {
                    throw new Exception("Unknown command");
                }

                await handler.ExecuteAsync(command);
            }
            catch(Exception e)
            {

            }
        }
    }
}