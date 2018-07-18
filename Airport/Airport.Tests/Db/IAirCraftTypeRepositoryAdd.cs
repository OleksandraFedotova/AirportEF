using Airport.Domain.Entities;
using Airport.Domain.Repositiories;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Airport.Tests.Db
{
    public class IAirCraftTypeRepositoryAdd : BaseDBScenario
    {
        private readonly Guid _id = Guid.NewGuid();

        protected override void Given()
        {

        }

        protected override async Task When()
        {
            var repo = Resolve<IAirCraftTypeRepository>();

            await repo.Create(new AirCraftType
            {
                Id = _id,
                LoadCapacity = 15,
                Model = "Airbus A320",
                Seats = 30
            });
        }

        [Test]
        public async Task AirCraftTypeAdded()
        {
            var repo = Resolve<IAirCraftTypeRepository>();

            var type = await repo.GetById(_id);

            Assert.IsNotNull(type);

            Assert.AreEqual(30, type.Seats);

            Assert.AreEqual(15, type.LoadCapacity);

            Assert.AreEqual("Airbus A320", type.Model);
        }

        [TearDown]
        public async Task Clear()
        {
            var repo = Resolve<IAirCraftTypeRepository>();

            await repo.Delete(_id);
        }
    }
}

