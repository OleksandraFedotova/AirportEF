using Abstractions.CQRS;
using System;
using System.Collections.Generic;

namespace Airport.Contract.Query.Pilot
{
    public class PilotsResponse : IResponse
    {
        public IEnumerable<Pilot> Pilots { get; set; }

        public class Pilot
        {
            public Guid Id { get; private set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime DateOfBirth { get; set; }
            public int Experience { get; set; }
        }
    }
}
