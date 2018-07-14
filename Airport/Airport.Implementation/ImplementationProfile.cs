using Airport.Contract.Command.AirCraft;
using Airport.Contract.Command.AirCraftType;
using Airport.Contract.Command.Crew;
using Airport.Contract.Command.Departure;
using Airport.Contract.Command.Flight;
using Airport.Contract.Command.Pilot;
using Airport.Contract.Command.Stewardress;
using Airport.Contract.Command.Ticket;
using Airport.Contract.Query.AirCraft;
using Airport.Contract.Query.AirCraftType;
using Airport.Contract.Query.Departure;
using Airport.Contract.Query.Pilot;
using Airport.Contract.Query.Stewardess;
using Airport.Contract.Query.Ticket;
using AutoMapper;

namespace Airport.Implementation
{
    public class ImplementationProfile : Profile
    {
        public ImplementationProfile()
        {
            CreateMap<Airport.Domain.Entities.Pilot, PilotByIdResponse>();
            CreateMap<Airport.Domain.Entities.Stewardess, StewardessByIdResponse>();
            CreateMap<Airport.Domain.Entities.AirCraft, AirCraftByIdResponse>();
            CreateMap<Airport.Domain.Entities.AirCraftType, AirCraftTypeByIdResponse>();
            CreateMap<Airport.Domain.Entities.Departure, DepartureByIdResponse>();
            CreateMap<Airport.Domain.Entities.Ticket, TicketByIdResponse>();

            CreateMap<CreatePilotCommand, Airport.Domain.Entities.Pilot>();
            CreateMap<CreateStewardessCommand, Airport.Domain.Entities.Stewardess>();
            CreateMap<CreateAirCraftCommand, Airport.Domain.Entities.AirCraft>().ForMember(x => x.AirCraftType, y => y.Ignore()); 
            CreateMap<CreateAirCraftTypeCommand, Airport.Domain.Entities.AirCraftType>();
            CreateMap<CreateDepartureCommand,Airport.Domain.Entities.Departure>();
            CreateMap<CreateTicketCommand,Airport.Domain.Entities.Ticket>().ForMember(x=>x.Flight,y=>y.Ignore());
            CreateMap<CreateFlightCommand, Airport.Domain.Entities.Flight>();
            CreateMap<CreateCrewCommand, Airport.Domain.Entities.Crew>();
        }
    }
}
