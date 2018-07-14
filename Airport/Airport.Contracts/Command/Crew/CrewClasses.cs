using System;
using System.Collections.Generic;
using System.Text;

namespace Airport.Contract.Command.Crew
{
    public class Pilot
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Experience { get; set; }
    }
    public class Stewardress
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
