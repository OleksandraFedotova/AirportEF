using Newtonsoft.Json;
using System;

namespace Airport.Web.Controllers
{
    public class UpdateDepartureModel
    {
        [JsonProperty("id")]
        public Guid DepartureId { get; set; }
        public int FlightNumber { get; set; }
        public DateTime DepartureDate { get; set; }
        public Guid CrewId { get; set; }
        public Guid AirCraftId { get; set; }
    }
}