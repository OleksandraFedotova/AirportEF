using Abstractions.CQRS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airport.Contract.Command.AirCraft
{
    public class DeleteAirCraftCommand : ICommand 
    {
        public Guid AirCraftId { get; set; }
    }
}
