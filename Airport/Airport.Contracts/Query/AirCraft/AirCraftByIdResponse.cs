using Abstractions.CQRS;
using System;

namespace Airport.Contract.Query.AirCraft
{
    public class AirCraftByIdResponse : IResponse
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public Guid TypeId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime TimeSpan { get; set; }
    }
}
