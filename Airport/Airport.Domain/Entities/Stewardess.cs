using System;
using Airport.Domain.Repositiories;

namespace Airport.Domain.Entities
{
    public class Stewardess : IEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
