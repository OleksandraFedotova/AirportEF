using Newtonsoft.Json;
using System;

namespace Airport.Web.Controllers
{
    public class UpdateAirCraftModel
    {
        [JsonProperty("id")]
        public Guid AirCraftId { get; set; }
        public string Name { get; set; }
        public Guid TypeId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime TimeSpan { get; set; }
    }
}