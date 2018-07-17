using Abstractions.CQRS;
using System;

namespace Airport.Contract.Command.Ticket
{
    public class CreateTicketCommand : ICommand
    {
        public Guid Id { get; set; }
        public double Price { get; set; }
        public int FlightNumber { get; set; }


        public CreateTicketCommand(Guid Id, double Price, int FlightNumber)
        {
            this.Id = Id;
            this.Price = Price;
            this.FlightNumber = FlightNumber;
        }
    }
}
