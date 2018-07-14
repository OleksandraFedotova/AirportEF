using Abstractions.CQRS;
using System;
using System.Collections.Generic;

namespace Airport.Contract.Query.Crew
{
    public class CrewsResponse:IResponse 
    {
       public IEnumerable<Crew> Crews { get; set; }
        public class Crew
        {
            public Guid Id { get; private set; }
            public IEnumerable<Stewardress> Stewardresses { get; set; }
            public Pilot Pilot { get; set; }
        }
    }
}
