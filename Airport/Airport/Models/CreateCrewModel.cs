using System;
using System.Collections.Generic;

namespace Airport.Web.Controllers
{
    public class CreateCrewModel
    {
        public IEnumerable<Guid> StewardessesId { get; set; }
        public Guid PilotId { get; set; }
    }
}