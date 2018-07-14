using Abstractions.CQRS;
using System;

namespace Airport.Contract.Query.Stewardess
{
    public class StewardessByIdResponse : IResponse
    {
        public Guid Id { get; private set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime DateOfBirth { get; set; }
    }
}
