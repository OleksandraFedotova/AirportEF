using Airport.Domain.Entities;
using Airport.Domain.Repositiories;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Airport.Tests.Db
{
    class IAirCraftRepositoryAddBaseDBScenario: BaseDBScenario
    {
        private readonly Guid _id = Guid.NewGuid();

        protected override void Given()
        {

        }

        protected override async Task When()
        {
            var repo = Resolve<IAirCraftRepository>();

            await repo.Create(new AirCraft
            {
                Id = _id,
                Name = "123",
                ReleaseDate = DateTime.Today,
                TimeSpan = DateTime.Today,
            });
        }

        [Test]
        public async Task AirCraftAdded()
        {
            var repo = Resolve<IAirCraftRepository>();

            var airCraft = await repo.GetById(_id);

            Assert.IsNotNull(airCraft);

            Assert.AreEqual("123", airCraft.Name);

            Assert.AreEqual(DateTime.Today, airCraft.ReleaseDate);

            Assert.AreEqual(DateTime.Today, airCraft.TimeSpan);
        }

        [TearDown]
        public async Task Clear()
        {
            var repo = Resolve<IAirCraftTypeRepository>();

            await repo.Delete(_id);
        }
    }
}
