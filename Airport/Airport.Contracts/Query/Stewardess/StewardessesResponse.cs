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
            string FirstName { get; set; }
            string LastName { get; set; }
            DateTime DateOfBirth { get; set; }
        }
    }
}
