using Abstractions.CQRS;
using System;
using System.Collections.Generic;

namespace Airport.Contract.Query.AirCraft
{
    public class AirCraftsResponse : IResponse
    {
        public IEnumerable<AirCraft> AirCrafts { get; set; }

        public class AirCraft
        {
            public Guid Id { get; private set; }
            public string Name { get; set; }
            public Guid TypeId { get; set; }
            public DateTime ReleaseDate { get; set; }
            public DateTime TimeSpan { get; set; }
        }
    }
}
