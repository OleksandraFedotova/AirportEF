using Abstractions.CQRS;
using System;

namespace Airport.Contract.Command.Departure
{
    public class CreateDepartureCommand : ICommand
    {
        public Guid Id { get; set; }
        public int FlightNumber { get; set; }
        public DateTime DepartureDate { get; set; }
        public Guid CrewId { get; set; }
        public Guid AirCraftId { get; set; }
    }

}
