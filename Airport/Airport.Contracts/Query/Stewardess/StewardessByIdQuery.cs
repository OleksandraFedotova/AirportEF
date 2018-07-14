using Abstractions.CQRS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airport.Contract.Query.Stewardess
{
    public class StewardessByIdQuery : IQuery<StewardessByIdResponse>
    {
        public Guid StewardessId { get; set; }
    }
}
