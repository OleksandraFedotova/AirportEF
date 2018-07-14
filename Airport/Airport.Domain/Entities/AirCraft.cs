using Airport.Domain.Repositiories;
using System;

namespace Airport.Domain.Entities
{
    public class AirCraft : IEntity
    {
        public string Name { get; set; }
        public Guid TypeId { get; set; }
        public AirCraftType AirCraftType { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime TimeSpan { get; set; }
        public Guid Id { get; set; }
    }
}
