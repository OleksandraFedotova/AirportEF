using Abstractions.CQRS;
using Airport.Contract.Query.Pilot;
using Airport.Domain.Repositiories;
using AirPort.DataAccess;
using AutoMapper;
using System;
using System.Threading.Tasks;

namespace Airport.Implementation.Hendlers.Query.Pilot
{
    public class PilotByIdQueryHandler : IQueryHandler<PilotByIdQuery, PilotByIdResponse>
    {
        private readonly IPilotRepository _pilotRepository;
        private readonly IMapper _mapper;

        public PilotByIdQueryHandler(IPilotRepository pilotRepository, IMapper mapper)
        {
            _pilotRepository = pilotRepository;
            _mapper = mapper;
        }

        public async Task<PilotByIdResponse> ExecuteAsync(PilotByIdQuery request)
        {
            var pilot = await _pilotRepository.GetById(request.PilotId);

            if (pilot == null)
            {
                throw new Exception("Idea not found");
            }

            var mappedPilot = _mapper.Map<PilotByIdResponse>(pilot);

            return mappedPilot;
        }
    }
}
