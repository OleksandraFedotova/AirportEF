using Airport.DataAccess;
using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace AirPort.DataAccess
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<FlightRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<CrewRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<AirCraftRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<AirCraftTypeRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<PilotRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<StewardessRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<TicketRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<DepartureRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();

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
}
