using Abstractions.CQRS;
using System;

namespace Airport.Contract.Query.Pilot
{
    public class PilotByIdQuery : IQuery<PilotByIdResponse>
    {
        public Guid PilotId { get; set; }
    }
}
