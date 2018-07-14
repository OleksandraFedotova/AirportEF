using Abstractions.CQRS;
using System;

namespace Airport.Contract.Command.Stewardress
{
    public class DeleteStewardessCommand : ICommand
    {
        public Guid StewardessId { get; set; }
    }
}
