using Abstractions.CQRS;
using System;

namespace Airport.Contract.Query.Flight
{
    public class FlightByIdQuery : IQuery<FlightByIdResponse>
    {
        public Guid FlightId { get; set; }
    }
}
