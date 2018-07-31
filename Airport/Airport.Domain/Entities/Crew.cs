using Airport.Domain.Repositiories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Airport.Domain.Entities
{
    public class Crew : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        public ICollection<Stewardess> Stewardesses { get; set; }
        public Pilot Pilot { get; set; }
    }
}
