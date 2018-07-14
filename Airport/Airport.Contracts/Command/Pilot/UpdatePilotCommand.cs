using Abstractions.CQRS;
using System;

namespace Airport.Contract.Command.Pilot
{
   public class UpdatePilotCommand : ICommand
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName {get;set;}
        public DateTime DateOfBirth { get; set; }
        public int Experience { get; set; }
    }
}
