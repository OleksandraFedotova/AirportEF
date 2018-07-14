using Abstractions.CQRS;
using System;
using System.Collections.Generic;

namespace Airport.Contract.Query.AirCraftType
{
    public class AirCraftTypesResponse : IResponse
    {
        public IEnumerable<AirCraftType> AirCraftTypes { get; set; }

        public class AirCraftType
        {
            public Guid Id { get; private set; }
            public string Model { get; set; }
            public int Places { get; set; }
            public int LoadCapacity { get; set; }
        }
    }
}
