using Abstractions.CQRS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airport.Contract.Command.AirCraft
{
  public  class UpdateAirCraftCommand : ICommand 
    {
        public Guid AirCraftId { get; set; }
        public string Name { get; set; }
        public Guid TypeId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime TimeSpan { get; set; }
    }
}
