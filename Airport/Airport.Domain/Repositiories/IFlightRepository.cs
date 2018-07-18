using Airport.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Airport.Domain.Repositiories
{
   public interface IFlightRepository: IRepository<Flight>
    {
        Task<Flight> GetByIdWithDelay(Guid id, double delay);
    }
}
