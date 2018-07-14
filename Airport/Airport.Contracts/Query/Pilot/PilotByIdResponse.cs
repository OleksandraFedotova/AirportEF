using Abstractions.CQRS;
using System;

namespace Airport.Contract.Query.Pilot
{
    public class PilotByIdResponse : IResponse
    {
        public Guid Id { get; private set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime DateOfBirth { get; set; }
        int Experience { get; set; }
    }
}
