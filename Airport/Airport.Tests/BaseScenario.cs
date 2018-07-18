using System;
using System.IO;
using Abstractions.Bus;
using Abstractions.CQRS;
using Airport.Implementation;
using AirPort.DataAccess;
using Autofac;
using Infrastructure;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public abstract class BaseScenario
    {
        public Exception Exception { get; private set; }

        protected abstract void Given();
        protected abstract void When();

        private IContainer _container;
        private ICommandBus _commandBus;
        private IQueryBus _requestBus;

        public IResponse Response { get; private set; }

        [SetUp]
        public void Setup()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<InfrastructureModule>();
            builder.RegisterModule<ImplementationModule>();
            builder.RegisterModule<TestDataAccessModule>();
            builder.RegisterModule<DataAccessModule>();

            _container = builder.Build();

            _requestBus = _container.Resolve<IQueryBus>();
            _commandBus = _container.Resolve<ICommandBus>();

            Given();

            When();
        }

        public T Resolve<T>() => _container.Resolve<T>();

        public async void SendCommand<TCommand>(TCommand command) where TCommand : ICommand
        {
            try
            {
                await _commandBus.ExecuteAsync(command);
            }
            catch (Exception e)
            {
                Exception = e;
            }
        }

        public async void SendRequest<TRequest, TResponse>(TRequest request)
            where TRequest : IQuery<TResponse>
            where TResponse : IResponse
        {
            try
            {
                Response = await _requestBus.RequestAsync<TRequest, TResponse>(request);
            }
            catch (Exception e)
            {
                Exception = e;
            }
        }
    }
}