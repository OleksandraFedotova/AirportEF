using Autofac;

namespace AirPort.DataAccess
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<FlightRepository>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<CrewRepository>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<AirCraftRepository>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<AirCraftTypeRepository>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<PilotRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<StewardessRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<TicketRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<DepartureRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();

        }
    }
}
