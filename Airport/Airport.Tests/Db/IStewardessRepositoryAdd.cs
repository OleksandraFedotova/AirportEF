using Airport.Domain.Repositiories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Tests.Db
{
  public  class IStewardessRepositoryAdd : BaseDBScenario
    {
        private readonly Guid _id = Guid.NewGuid();

        protected override void Given()
        {

        }

        protected override async Task When()
        {
            var repo = Resolve<IStewardessRepository>();

            await repo.Create(new Domain.Entities.Stewardess
            {
                Id = _id,
                FirstName = "A",
                LastName = "B",
                DateOfBirth = DateTime.Today
            });
        }

        [Test]
        public async Task AirCraftTypeAdded()
        {
            var repo = Resolve<IPilotRepository>();

            var stewardess = await repo.GetById(_id);

            Assert.IsNotNull(stewardess);

            Assert.AreEqual("A", stewardess.FirstName);

            Assert.AreEqual("B", stewardess.LastName);

            Assert.AreEqual(DateTime.Today, stewardess.DateOfBirth);
        }

        [TearDown]
        public async Task Clear()
        {
            var repo = Resolve<IStewardessRepository>();

            await repo.Delete(_id);
        }
    }
}
