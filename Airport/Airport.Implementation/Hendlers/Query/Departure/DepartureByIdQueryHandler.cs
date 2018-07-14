using Abstractions.CQRS;
using Airport.Contract.Query.Departure;
using Airport.Domain.Repositiories;
using AirPort.DataAccess;
using AutoMapper;
using System;
using System.Threading.Tasks;

namespace Airport.Implementation.Hendlers.Query.Departure
{
    public class DepartureByIdQueryHandler : IQueryHandler<DepartureByIdQuery, DepartureByIdResponse>
    {
        private readonly IDepartureRepository _departureRepository;
        private readonly IMapper _mapper;

        public DepartureByIdQueryHandler(IDepartureRepository departureRepository, IMapper mapper)
        {
            _departureRepository = departureRepository;
            _mapper = mapper;
        }

        public async Task<DepartureByIdResponse> ExecuteAsync(DepartureByIdQuery request)
        {
            var departure = await _departureRepository.GetById(request.DepartureId);

            if (departure == null)
            {
                throw new Exception("Departure not found");
            }

            var mappedDeparture = _mapper.Map<DepartureByIdResponse>(departure);

            return mappedDeparture;
        }
    }
}
