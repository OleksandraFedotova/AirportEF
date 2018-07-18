using System;
using System.Collections.Generic;

namespace Airport.Web.Models
{
    internal class TenCrewsModel
    {
        public int Id { get; set; }
        public IEnumerable<PilotModel> Pilot { get; set; }
        public IEnumerable<StewardessesModel> Stewardess { get; set; }

        public class PilotModel
        {
            public int Id { get; set; }
            public int CrewId { get; set; }
            public DateTime BirthDate { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Exp { get; set; }
        }

        public class StewardessesModel
        {
            public int Id { get; set; }
            public int CrewId { get; set; }
            public DateTime BirthDate { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}