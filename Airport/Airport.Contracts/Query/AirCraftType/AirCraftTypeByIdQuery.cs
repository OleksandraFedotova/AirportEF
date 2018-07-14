using Abstractions.CQRS;
using Airport.Contract.Query.AirCraftType;
using System;

namespace Airport.Contract.Query.AirCraft
{
    public class AirCraftTypeByIdQuery : IQuery<AirCraftTypeByIdResponse>
    {
        public Guid AirCraftTypeId { get; set; }
    }
}
