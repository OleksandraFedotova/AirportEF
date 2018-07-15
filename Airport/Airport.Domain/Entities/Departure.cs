using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Airport.Domain.Repositiories;

namespace Airport.Domain.Entities
{
    public class Departure : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        public int FlightNumber { get; set; }
        public DateTime DepartureDate { get; set; }

        [ForeignKey("Crew")]
        public Guid CrewId { get; set; }

        [ForeignKey("AirCraft")]
        public Guid AirCraftId { get; set; }
    }
}
