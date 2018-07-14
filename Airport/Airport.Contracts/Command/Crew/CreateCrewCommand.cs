using Abstractions.CQRS;
using System;
using System.Collections.Generic;

namespace Airport.Contract.Command.Crew
{
    public class CreateCrewCommand : ICommand
    {
        public Guid Id { get; set; }
        public IEnumerable<Guid> StewardressesId { get; set; }
        public Guid PilotId { get; set; }
    }
}
