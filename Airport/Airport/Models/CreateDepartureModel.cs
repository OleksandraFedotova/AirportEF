using System;

namespace Airport.Web.Controllers
{
    public class CreateDepartureModel
    {
        public int FlightNumber { get; set; }
        public DateTime DepartureDate { get; set; }
        public Guid CrewId { get; set; }
        public Guid AirCraftId { get; set; }
    }
}