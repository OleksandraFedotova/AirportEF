using Newtonsoft.Json;
using System;

namespace Airport.Web.Controllers
{
    public class UpdateTicketModel
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        public double Price { get; set; }
        public int FlightNumber { get; set; }
    }
}