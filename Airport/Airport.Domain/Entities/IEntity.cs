using System;
using System.Collections.Generic;
using System.Text;

namespace Airport.Domain.Repositiories
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
