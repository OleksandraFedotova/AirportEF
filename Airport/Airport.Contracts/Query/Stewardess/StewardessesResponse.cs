using Abstractions.CQRS;
using System;
using System.Collections.Generic;

namespace Airport.Contract.Query.Stewardess
{
    public class StewardessesResponse : IResponse
    {
      public IEnumerable<Stewardess> Stewardesses { get; set; }

        public class Stewardess
        {
            public Guid Id { get; private set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime DateOfBirth { get; set; }
        }
    }
}
