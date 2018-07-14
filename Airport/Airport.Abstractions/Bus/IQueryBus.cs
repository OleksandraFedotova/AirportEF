using System.Threading.Tasks;
using Abstractions.CQRS;

namespace Abstractions.Bus
{
    public interface IQueryBus
    {
        Task<TResponse> RequestAsync<TQuery, TResponse>(TQuery request)
            where TQuery : IQuery<TResponse>
            where TResponse : IResponse;
    }
}