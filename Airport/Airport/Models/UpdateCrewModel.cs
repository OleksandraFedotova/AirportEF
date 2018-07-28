using Airport.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Airport.Web.Controllers
{
    public class UpdateCrewModel
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        public IEnumerable<Guid> StewardessesId { get; set; }
        public Guid PilotId { get; set; }
    }
}