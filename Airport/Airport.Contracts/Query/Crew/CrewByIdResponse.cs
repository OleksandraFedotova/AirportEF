using Abstractions.CQRS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airport.Contract.Query.Crew
{
  public  class CrewByIdResponse:IResponse 
    {
        public Guid Id { get; private set; }
        public IEnumerable<Stewardress> Stewardresses { get; set; }
        public Pilot Pilot { get; set; }
    }
}
