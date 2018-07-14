using Abstractions.CQRS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airport.Contract.Command.AirCraftType
{
    public class DeleteAirCraftTypeCommand : ICommand
    {
        public Guid AirCraftTypeId { get; set; }
    }
}
