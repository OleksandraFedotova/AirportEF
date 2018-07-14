using Abstractions.CQRS;
using System;

namespace Airport.Contract.Command.Departure
{
    public class DeleteDepartureCommand : ICommand
    {
        public Guid DepartureId { get; set; }
    }
}
