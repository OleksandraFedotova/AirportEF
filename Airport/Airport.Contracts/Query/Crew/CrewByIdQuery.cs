using Abstractions.CQRS;
using System;

namespace Airport.Contract.Query.Crew
{
    public  class CrewByIdQuery:IQuery<CrewByIdResponse>
    {
        public Guid CrewId { get; set; }
    }
}
