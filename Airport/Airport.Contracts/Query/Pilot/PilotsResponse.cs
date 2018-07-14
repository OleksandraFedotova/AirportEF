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
            string FirstName { get; set; }
            string LastName { get; set; }
            DateTime DateOfBirth { get; set; }
            int Experience { get; set; }
        }
    }
}
