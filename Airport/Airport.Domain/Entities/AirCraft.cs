using Airport.Domain.Repositiories;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airport.Domain.Entities
{
    public class AirCraft : IEntity
    {
        [Required]
        public string Name { get; set; }
        [ForeignKey("AirCraftType")]
        public Guid TypeId { get; set; }
        public AirCraftType AirCraftType { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime TimeSpan { get; set; }
        [Key]
        public Guid Id { get; set; }
    }
}
