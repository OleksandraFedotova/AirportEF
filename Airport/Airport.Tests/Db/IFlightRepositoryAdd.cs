using Airport.Domain.Repositiories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Tests.Db
{
   public class IFlightRepositoryAdd : BaseDBScenario
    {
        private readonly Guid _id = Guid.NewGuid();

        protected override void Given()
        {

        }

        protected override async Task When()
        {
            var repo = Resolve<IFlightRepository>();

            await repo.Create(new Domain.Entities.Flight
            {
                Id = _id,
                DeparturePoint="Kyiv",
                DepartureTime=DateTime.Today,
                Destination="Dnipro",
                Number=1,
                TimeOfArrival=DateTime.Today
            });
        }

        [Test]
        public async Task AirCraftTypeAdded()
        {
            var repo = Resolve<IFlightRepository>();

            var flight = await repo.GetById(_id);

            Assert.IsNotNull(flight);

            Assert.AreEqual("Kyiv", flight.DeparturePoint);
            Assert.AreEqual(DateTime.Today, flight.DepartureTime);
            Assert.AreEqual(1, flight.Number);
            Assert.AreEqual("Dnipro", flight.Destination);
            Assert.AreEqual(DateTime.Today, flight.TimeOfArrival);
        }

        [TearDown]
        public async Task Clear()
        {
            var repo = Resolve<IFlightRepository>();

            await repo.Delete(_id);
        }
    }
}
