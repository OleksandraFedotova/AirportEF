using Abstractions.CQRS;
using Airport.Contract.Query.Crew;
using Airport.Domain.Repositiories;
using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Airport.Implementation.Hendlers.Query.Crew
{
    public class CrewsQueryHandler : IQueryHandler<CrewsQuery, CrewsResponse>
    {
        private readonly ICrewRepository _crewRepository;
        private readonly IMapper _mapper;

        public CrewsQueryHandler(ICrewRepository crewRepository, IMapper mapper)
        {
            _crewRepository = crewRepository;
            _mapper = mapper;
        }

        public async Task<CrewsResponse> ExecuteAsync(CrewsQuery request)
        {
            var crews = _crewRepository.GetAll();

            if (crews == null)
            {
                throw new Exception("Crews not found");
            }

            var mappedCrew = new CrewsResponse
            {
                Crews = crews.Select(_mapper.Map<Domain.Entities.Crew, CrewsResponse.Crew>).ToList()
            };


            return mappedCrew;
        }

    }
}
