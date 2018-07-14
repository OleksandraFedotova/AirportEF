using Abstractions.CQRS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airport.Contract.Command.Flight
{
    public class CreateFlightCommand : ICommand
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string DeparturePoint{get;set;}
        public DateTime DepartureTime { get; set; }
        public string Destination { get; set; }
        public DateTime TimeOfArrival{ get; set; }
        public IEnumerable<Guid> TicketsId { get; set; }
    }
}
