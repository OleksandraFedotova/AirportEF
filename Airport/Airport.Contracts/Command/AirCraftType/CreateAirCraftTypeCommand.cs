using Abstractions.CQRS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airport.Contract.Command.AirCraftType
{
    public class CreateAirCraftTypeCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Model { get; set; }
        public int Seats { get; set; }
        public int LoadCapacity { get; set; }
    }
}
