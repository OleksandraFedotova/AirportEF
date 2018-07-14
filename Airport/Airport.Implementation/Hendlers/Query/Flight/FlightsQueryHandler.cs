using Abstractions.CQRS;
using Airport.Contract.Query.Crew;
using Airport.Contract.Query.Flight;
using Airport.Domain.Repositiories;
using AirPort.DataAccess;
using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Airport.Implementation.Hendlers.Query.Crew
{
    public class FlightsQueryHandler : IQueryHandler<FlightsQuery, FlightsResponse>
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IMapper _mapper;

        public FlightsQueryHandler(IFlightRepository flightRepository, IMapper mapper)
        {
            _flightRepository = flightRepository;
            _mapper = mapper;
        }

        public async Task<FlightsResponse> ExecuteAsync(FlightsQuery request)
        {
            var flights = _flightRepository.GetAll();

            if (flights == null)
            {
                throw new Exception("Flights not found");
            }

            var mappedCrew = new FlightsResponse
            {
                Flights = flights.Select(_mapper.Map<Domain.Entities.Flight, FlightsResponse.Flight>).ToList()
            };

            return mappedCrew;
        }

    }
}
