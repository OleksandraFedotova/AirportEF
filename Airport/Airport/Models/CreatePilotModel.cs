using System;

namespace Airport.Web.Controllers
{
    public class CreatePilotModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Experience { get; set; }
    }
}