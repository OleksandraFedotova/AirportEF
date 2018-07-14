using Abstractions.CQRS;
using System;

namespace Airport.Contract.Command.Crew
{
    public class DeleteCrewCommand:ICommand
    {
        public Guid CrewId { get; set; }
    }
}
