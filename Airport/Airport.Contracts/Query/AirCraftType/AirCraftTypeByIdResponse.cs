using Abstractions.CQRS;
using System;

namespace Airport.Contract.Query.AirCraftType
{
    public class AirCraftTypeByIdResponse : IResponse
    {
        public Guid Id { get; private set; }
        public string Model { get; set; }
        public int Places { get; set; }
        public int LoadCapacity { get; set; }
    }
}
