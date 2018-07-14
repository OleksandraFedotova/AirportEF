using System;

namespace Airport.Web.Controllers
{
    public class CreateAirCraftModel
    {
        public string Name { get; set; }
        public Guid TypeId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime TimeSpan { get; set; }
    }
}