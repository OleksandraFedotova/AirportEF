using Abstractions.CQRS;
using System;

namespace Airport.Contract.Query.AirCraft
{
    public class AirCraftByIdQuery : IQuery<AirCraftByIdResponse>
    {
        public Guid AirCraftId { get; set; }
    }
}
