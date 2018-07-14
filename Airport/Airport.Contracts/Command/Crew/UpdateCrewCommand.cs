using Abstractions.CQRS;
using System;
using System.Collections.Generic;

namespace Airport.Contract.Command.Crew
{
    public class UpdateCrewCommand : ICommand
    {
        public Guid CrewId { get; set; }
        public IEnumerable<Guid> StewardressesId { get; set; }
        public Guid PilotId
        {
            get; set;
        }
    }
}

