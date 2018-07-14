using Abstractions.CQRS;
using System;

namespace Airport.Contract.Command.AirCraft
{
    public class CreateAirCraftCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid TypeId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime TimeSpan { get; set; }

    }
}
