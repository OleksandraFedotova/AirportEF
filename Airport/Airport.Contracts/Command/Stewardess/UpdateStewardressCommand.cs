using Abstractions.CQRS;
using System;

namespace Airport.Contract.Command.Stewardress
{
    public class UpdateStewardressCommand : ICommand
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
