using Abstractions.CQRS;
using Airport.Contract.Query.Pilot;
using Airport.Domain.Repositiories;
using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Airport.Implementation.Hendlers.Query.Pilot
{
    public class PilotsQueryHandler : IQueryHandler<PilotsQuery, PilotsResponse>
    {
        private readonly IPilotRepository _pilotRepository;
        private readonly IMapper _mapper;

        public PilotsQueryHandler(IPilotRepository pilotRepository, IMapper mapper)
        {
            _pilotRepository = pilotRepository;
            _mapper = mapper;
        }

        public async Task<PilotsResponse> ExecuteAsync(PilotsQuery request)
        {
            var pilots = _pilotRepository.GetAll();

            if (pilots == null)
            {
                throw new Exception("Pilots not found");
            }

            var mappedPilot = new PilotsResponse
            {
                Pilots = pilots.Select(_mapper.Map<Domain.Entities.Pilot, PilotsResponse.Pilot>).ToList()
            };



            return mappedPilot;
        }

    }
}
