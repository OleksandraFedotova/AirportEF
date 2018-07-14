using Airport.Domain.Repositiories;
using System;
using System.Collections.Generic;

namespace Airport.Domain.Entities
{
    public class Crew : IEntity
    {
        public Guid Id { get; set; }
        public IEnumerable<Stewardess> Stewardesses { get; set; }
        public Pilot Pilot { get; set; }
    }
}
