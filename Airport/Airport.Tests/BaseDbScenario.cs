using AirPort.DataAccess;
using Autofac;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Tests
{

    [TestFixture]
    public abstract class BaseDBScenario
    {
        public Exception Exception { get; private set; }

        protected abstract void Given();
        protected abstract Task When();

        private IContainer _container;

        [SetUp]
        public async Task Setup()
        {
            var builder = new ContainerBuilder();

            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().LastIndexOf("\\bin\\Debug\\netcoreapp2.0")))
                .AddJsonFile("appsettings.json");

            builder.RegisterInstance(configBuilder.Build()).As<IConfiguration>();

            builder.RegisterModule<DataAccessModule>();

            _container = builder.Build();

            Given();

            try
            {
                await When();
            }
            catch (Exception e)
            {
                Exception = e;
            }
        }
        public T Resolve<T>() => _container.Resolve<T>();
    }
}
