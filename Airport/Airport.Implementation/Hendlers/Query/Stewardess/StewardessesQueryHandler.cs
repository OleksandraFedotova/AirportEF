using Abstractions.CQRS;
using Airport.Contract.Query.Stewardess;
using Airport.Domain.Repositiories;
using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Airport.Implementation.Hendlers.Query.Stewardess
{
    public class StewardessesQueryHandler : IQueryHandler<StewardessesQuery, StewardessesResponse>
    {
        private readonly IStewardessRepository _stewardessRepository;
        private readonly IMapper _mapper;

        public StewardessesQueryHandler(IStewardessRepository stewardessRepository, IMapper mapper)
        {
            _stewardessRepository = stewardessRepository;
            _mapper = mapper;
        }

        public async Task<StewardessesResponse> ExecuteAsync(StewardessesQuery request)
        {
            var stewardesss = _stewardessRepository.GetAll();

            if (stewardesss == null)
            {
                throw new Exception("Stewardesses not found");
            }

            var mappedStewardess = new StewardessesResponse
            {
                Stewardesses = stewardesss.Select(_mapper.Map<Domain.Entities.Stewardess, StewardessesResponse.Stewardess>).ToList()
            };

            return mappedStewardess;
        }

    }
}
