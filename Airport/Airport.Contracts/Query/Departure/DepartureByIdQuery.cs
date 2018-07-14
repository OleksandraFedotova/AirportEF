using Abstractions.CQRS;
using System;

namespace Airport.Contract.Query.Departure
{
    public class DepartureByIdQuery : IQuery<DepartureByIdResponse>
    {
        public Guid DepartureId { get; set; }
    }
}
