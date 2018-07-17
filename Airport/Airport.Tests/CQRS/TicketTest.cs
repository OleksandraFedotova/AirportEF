using Airport.Contract.Command.Ticket;
using Airport.DataAccess;
using Airport.Domain.Entities;
using NUnit.Framework;
using System;
using System.Linq;
using Tests;

namespace Airport.Tests.CQRS
{
    public class TicketAdded : BaseScenario
    {
        private readonly Guid _ticketId = Guid.NewGuid();

        protected override void Given()
        {
            var context = Resolve<AirportDbContext>();

            context.Tickets.Add(new Ticket
            {
                Id = _ticketId
            });

            context.SaveChanges();
        }

        protected override void When()
        {
            SendCommand(new CreateTicketCommand ( _ticketId, 1234, 23 ));
        }

        [Test]
        public void TicketAddedSuccessfully()
        {
            var context = Resolve<AirportDbContext>();

            var ticket = context.Tickets.FirstOrDefault(i => i.Id == _ticketId);

            Assert.IsNotNull(ticket);
        }

        public void NoException()
        {
            Assert.IsNull(Exception);
        }
    }
}
