using Airport.DataAccess;
using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AirPort.DataAccess
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterContext(builder);

            builder.RegisterType<FlightRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<CrewRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<AirCraftRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<AirCraftTypeRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<PilotRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<StewardessRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<TicketRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<DepartureRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();
        }

        protected virtual void RegisterContext(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var configuration = c.Resolve<IConfiguration>();

                DbContextOptions<AirportDbContext> options = new DbContextOptionsBuilder<AirportDbContext>()
                    .UseSqlServer(configuration.GetConnectionString("AirportDatabase")).Options;

                return options;
            });

            builder.RegisterType<AirportDbContext>().AsSelf().InstancePerLifetimeScope();
        }
    }

    public class TestDataAccessModule : DataAccessModule
    {
        protected override void RegisterContext(ContainerBuilder builder)
        {
            builder.Register(c=>MockedDbContext.Create()).As<AirportDbContext>().InstancePerLifetimeScope();
        }
    }
}
