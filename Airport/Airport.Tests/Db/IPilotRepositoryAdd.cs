using Airport.Domain.Repositiories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Airport.Domain.Entities;
using System.Threading.Tasks;

namespace Airport.Tests.Db
{
    public class IPilotRepositoryAdd : BaseDBScenario
    {
        private readonly Guid _id = Guid.NewGuid();

        protected override void Given()
        {

        }

        protected override async Task When()
        {
            var repo = Resolve<IPilotRepository>();

            await repo.Create(new Pilot
            {
                Id = _id,
                FirstName="A",
                LastName="B",
                DateOfBirth=DateTime.Today,
                Experience=1
            });
        }

        [Test]
        public async Task AirCraftTypeAdded()
        {
            var repo = Resolve<IPilotRepository>();

            var pilot = await repo.GetById(_id);

            Assert.IsNotNull(pilot);

            Assert.AreEqual("A", pilot.FirstName);

            Assert.AreEqual("B", pilot.LastName);

            Assert.AreEqual(1, pilot.Experience);

            Assert.AreEqual(DateTime.Today, pilot.DateOfBirth);
        }

        [TearDown]
        public async Task Clear()
        {
            var repo = Resolve<IPilotRepository>();

            await repo.Delete(_id);
        }
    }
}
