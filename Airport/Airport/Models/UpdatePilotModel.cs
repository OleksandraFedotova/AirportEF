using Newtonsoft.Json;
using System;

namespace Airport.Web.Controllers
{
    public class UpdatePilotModel
    {
        [JsonProperty("id")]
        public Guid PilotId {get;set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Experience { get; set; }
    }
}