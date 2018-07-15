using System;
using System.ComponentModel.DataAnnotations;
using Airport.Domain.Repositiories;

namespace Airport.Domain.Entities
{
    public class Ticket : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        public double Price { get; set; }
        public int FlightNumber { get; set; }
        public Flight Flight { get; set; }
    }
}
