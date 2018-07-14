using Abstractions.CQRS;
using Airport.Contract.Query.AirCraft;
using Airport.Domain.Repositiories;
using AirPort.DataAccess;
using AutoMapper;
using System;
using System.Threading.Tasks;

namespace Airport.Implementation.Hendlers.Query.AirCraft
{
    public class AirCraftByIdQueryHandler : IQueryHandler<AirCraftByIdQuery, AirCraftByIdResponse>
    {
        private readonly IAirCraftRepository _airCraftRepository;
        private readonly IMapper _mapper;

        public AirCraftByIdQueryHandler(IAirCraftRepository airCraftRepository, IMapper mapper)
        {
            _airCraftRepository = airCraftRepository;
            _mapper = mapper;
        }

        public async Task<AirCraftByIdResponse> ExecuteAsync(AirCraftByIdQuery request)
        {
            var airCraft = await _airCraftRepository.GetById(request.AirCraftId);

            if (airCraft == null)
            {
                throw new Exception("AirCraft not found");
            }

            var mappedAirCraft = _mapper.Map<AirCraftByIdResponse>(airCraft);

            return mappedAirCraft;
        }
    }
}
