using Abstractions.CQRS;
using Airport.Contract.Query.Crew;
using Airport.Contract.Query.Departure;
using Airport.Domain.Repositiories;
using AirPort.DataAccess;
using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Airport.Implementation.Hendlers.Query.Crew
{
    public class DeparturesQueryHandler : IQueryHandler<DeparturesQuery, DeparturesResponse>
    {
        private readonly IDepartureRepository _departureRepository;
        private readonly IMapper _mapper;

        public DeparturesQueryHandler(IDepartureRepository departureRepository, IMapper mapper)
        {
            _departureRepository = departureRepository;
            _mapper = mapper;
        }

        public async Task<DeparturesResponse> ExecuteAsync(DeparturesQuery request)
        {
            var departures = _departureRepository.GetAll();

            if (departures == null)
            {
                throw new Exception("Departures not found");
            }

            var mappedCrew = new DeparturesResponse
            {
                Departures = departures.Select(_mapper.Map<Domain.Entities.Departure, DeparturesResponse.Departure>).ToList()
            };

            return mappedCrew;
        }

    }
}
