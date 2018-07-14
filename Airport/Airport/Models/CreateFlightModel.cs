using System;
using System.Collections.Generic;

namespace Airport.Web.Controllers
{
    public class CreateFlightModel
    {
        public int Number { get; set; }
        public string DeparturePoint { get; set; }
        public DateTime DepartureTime { get; set; }
        public string Destination { get; set; }
        public DateTime TimeOfArrival { get; set; }
        public IEnumerable<Guid> TicketsId { get; set; }
    }
}