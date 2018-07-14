using Abstractions.CQRS;
using System;

namespace Airport.Contract.Command.Pilot
{
   public class DeletePilotCommand : ICommand
    {
        public Guid PilotId { get; set; }
    }
}
