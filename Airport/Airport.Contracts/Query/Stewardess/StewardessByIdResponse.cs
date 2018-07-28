using Abstractions.CQRS;
using System;

namespace Airport.Contract.Query.Stewardess
{
    public class StewardessByIdResponse : IResponse
    {
        public Guid Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
