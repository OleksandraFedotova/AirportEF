using System.Threading.Tasks;

namespace Abstractions.CQRS
{
    public interface IQueryHandler<in TQuery, TResponse>
        where TQuery : IQuery<TResponse> where TResponse : IResponse
    {
        Task<TResponse> ExecuteAsync(TQuery request);
    }
}