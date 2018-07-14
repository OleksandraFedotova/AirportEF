using Abstractions.CQRS;
using Autofac;
using AutoMapper;

namespace Airport.Implementation
{
    public class ImplementationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                .AsClosedTypesOf(typeof(ICommandHandler<>))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .AsClosedTypesOf(typeof(IQueryHandler<,>))
                .AsImplementedInterfaces();

            builder.Register(c => new MapperConfiguration(cfg => cfg.AddProfile(new ImplementationProfile()))).AsSelf()
                .SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve)).As<IMapper>()
                .SingleInstance();
        }
    }
}
