using System;
using System.Threading.Tasks;
using Abstractions.Bus;
using Abstractions.CQRS;
using Autofac;

namespace Infrastructure.Bus
{
    public class QueryBus : IQueryBus
    {
        private readonly ILifetimeScope _container;

        public QueryBus(ILifetimeScope container)
        {
            _container = container;
        }

        public async Task<TResponse> RequestAsync<TQuery, TResponse>(TQuery request) where TQuery : IQuery<TResponse> where TResponse : IResponse
        {
            var handler = _container.ResolveOptional<IQueryHandler<TQuery, TResponse>>();

            if (handler == null)
            {
                throw new Exception("Unknown request");
            }

            return await handler.ExecuteAsync(request);
        }
    }
}